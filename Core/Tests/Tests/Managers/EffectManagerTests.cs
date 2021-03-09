using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Managers.Managers;
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
            var effectModel = Fixture
                .Build<EffectModel>()
                .With(x => x.ResourceEffects, new List<ResourceEffectModel>()
                )
                .Create();
            
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
            var effectModel = Fixture
                .Build<EffectModel>()
                .With(x => x.ResourceEffects,
                        Fixture.CreateMany<ResourceEffectModel>(resourceEffectCount).ToList
                    )
                .Create();

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
    }
}