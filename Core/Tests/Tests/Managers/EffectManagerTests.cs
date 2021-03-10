﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Managers.Managers;
using Models.Enums;
using Models.Models;
using Models.Models.Effects;
using NUnit.Framework;

namespace Tests.Tests.Managers
{
    public class EffectManagerTests : BaseTest<EffectManager>
    {
        private EffectStorageModel _effectStorageModel;
        
        [SetUp]
        public void SetUp()
        {
            _effectStorageModel = new EffectStorageModel();
            Service = new EffectManager(_effectStorageModel);
        }

        [Test]
        public void Add_success()
        {
            var effectModel = Fixture.Create<EffectModel>();
            Service.Add(effectModel);

            var addedEffect = _effectStorageModel.Effects.FirstOrDefault();
            Assert.NotNull(addedEffect);
            Assert.AreEqual(effectModel.Id, addedEffect.Key);
            Assert.AreEqual(effectModel, addedEffect.Value);
        }
        
        [Test]
        public void Add_WithoutResources_NotAddToResourceDictionary()
        {
            var effectModel = CreateEffect();
            
            Service.Add(effectModel);

            var resourceEffects = _effectStorageModel.ResourceEffects.FirstOrDefault();
            Assert.AreEqual(resourceEffects, new KeyValuePair<Guid,EffectModel>());
            
            var addedEffect = _effectStorageModel.Effects.FirstOrDefault();
            Assert.NotNull(addedEffect);
            Assert.AreEqual(effectModel.Id, addedEffect.Key);
            Assert.AreEqual(effectModel, addedEffect.Value);
        }
        
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        public void Add_NotEmptyResource_Success(int resourceEffectCount)
        {
            var effectModel = CreateEffect(
                Fixture
                    .CreateMany<ResourceEffectModel>(resourceEffectCount)
                    .ToArray());

            Service.Add(effectModel);

            var resourceEffects = _effectStorageModel.ResourceEffects.FirstOrDefault();
            Assert.NotNull(resourceEffects);
            Assert.AreEqual(effectModel.Id, resourceEffects.Key);
            Assert.AreEqual(effectModel, resourceEffects.Value);
            
            var addedEffect = _effectStorageModel.Effects.FirstOrDefault();
            Assert.NotNull(addedEffect);
            Assert.AreEqual(effectModel.Id, addedEffect.Key);
            Assert.AreEqual(effectModel, addedEffect.Value);
        }
        
        [Test]
        public void GetResources_NoEffects_EmptyResult()
        {
            var result = Service.GetResourceEffects();
            
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }
        
        [Test]
        public void GetResources_OneEffect_EmptyResult()
        {
            var resourceModel = Fixture.Create<ResourceEffectModel>();
            var existingEffect = CreateEffect(resourceModel);

            _effectStorageModel.ResourceEffects.TryAdd(existingEffect.Id, existingEffect);
            
            var result = Service.GetResourceEffects();
            
            Assert.AreEqual(result.Count, 1);
            var resource = result.FirstOrDefault();
            Assert.AreEqual(resourceModel, resource);
        }
        
        [Theory]
        public void GetResources_TwoEffects(
            ResourceType firstResourceType,
            ResourceType secondResourceType)
        {
            var firstResourceModel = CreateResourceEffect(firstResourceType);
            var secondResourceModel = CreateResourceEffect(secondResourceType);
            
            var existingEffect = CreateEffect(firstResourceModel, secondResourceModel);

            _effectStorageModel.ResourceEffects.TryAdd(existingEffect.Id, existingEffect);
            
            var result = Service.GetResourceEffects();
            
            Assert.AreEqual(result.Count, 2);
            Assert.IsTrue(result.Any(x => x == firstResourceModel));
            Assert.IsTrue(result.Any(x => x == secondResourceModel));
        }

        [Theory]
        public void GetResources_TwoResourceEffectsFromDifferentEffects(
            ResourceType firstResourceType,
            ResourceType secondResourceType)
        {
            var firstResourceModel = CreateResourceEffect(firstResourceType);
            var secondResourceModel = CreateResourceEffect(secondResourceType);

            var existingEffect1 = CreateEffect(firstResourceModel);
            var existingEffect2 = CreateEffect(secondResourceModel);

            _effectStorageModel.ResourceEffects.TryAdd(existingEffect1.Id, existingEffect1);
            _effectStorageModel.ResourceEffects.TryAdd(existingEffect2.Id, existingEffect2);

            var result = Service.GetResourceEffects();

            Assert.AreEqual(result.Count, 2);
            Assert.IsTrue(result.Any(x => x == firstResourceModel));
            Assert.IsTrue(result.Any(x => x == secondResourceModel));
        }
        
        [Test]
        public async Task RemoveNotActual_EmptyList()
        {
            await Service.RemoveNotActual(new TimeSpan());

            Assert.IsEmpty(_effectStorageModel.Effects);
            Assert.IsEmpty(_effectStorageModel.ResourceEffects);
        }
        
        [TestCase("0:00", "0:10")]
        [TestCase("0:10", "0:10")]
        [TestCase("0:00", "0:00")]
        public async Task RemoveNotActual_NotExpired(TimeSpan currentTime, TimeSpan period)
        {
            var effect = Fixture
                .Build<EffectModel>()
                .With(x => x.Period, period)
                .Create();

            _effectStorageModel.Effects.TryAdd(effect.Id, effect);
            _effectStorageModel.ResourceEffects.TryAdd(effect.Id, effect);
            
            await Service.RemoveNotActual(currentTime);

            Assert.IsNotEmpty(_effectStorageModel.Effects);
            Assert.IsNotEmpty(_effectStorageModel.ResourceEffects);
        }
        
        [TestCase("0:10", "0:00")]
        [TestCase("0:10", "0:05")]
        public async Task RemoveNotActual_IsExpired(TimeSpan currentTime, TimeSpan period)
        {
            var effect = Fixture
                .Build<EffectModel>()
                .With(x => x.Period, period)
                .Create();

            _effectStorageModel.Effects.TryAdd(effect.Id, effect);
            
            await Service.RemoveNotActual(currentTime);

            Assert.IsEmpty(_effectStorageModel.Effects);
        }
        
        [TestCase("0:10", "0:00")]
        [TestCase("0:10", "0:05")]
        public async Task RemoveNotActual_IsExpired_WithResources(TimeSpan currentTime, TimeSpan period)
        {
            var effect = Fixture
                .Build<EffectModel>()
                .With(x => x.Period, period)
                .Create();

            _effectStorageModel.Effects.TryAdd(effect.Id, effect);
            _effectStorageModel.ResourceEffects.TryAdd(effect.Id, effect);
            
            await Service.RemoveNotActual(currentTime);

            Assert.IsEmpty(_effectStorageModel.Effects);
            Assert.IsEmpty(_effectStorageModel.ResourceEffects);
        }

        private ResourceEffectModel CreateResourceEffect(ResourceType resourceType)
        {
            return Fixture
                .Build<ResourceEffectModel>()
                .With(x => x.ResourceType, resourceType)
                .Create();
        }
        
        private EffectModel CreateEffect(params ResourceEffectModel[] resourceType)
        {
            return Fixture
                .Build<EffectModel>()
                .With(x => x.ResourceEffects,
                    new List<ResourceEffectModel>(resourceType))
                .Create();
        }
    }
}