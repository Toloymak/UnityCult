namespace Models.Models
{
    public readonly struct Coordinates
    {
        public int X { get; }
        public int Z { get; }

        public Coordinates(int x, int z)
        {
            X = x;
            Z = z;
        }
        
        public override string ToString()
        {
            return $"({X}; {Z})";
        }
    }
}