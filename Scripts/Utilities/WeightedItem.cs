namespace IFuzeHostage.SpinWheel.Utilities
{
    internal class WeightedItem<T>
    {
        public T Item { get; set; }
        public float Weight { get; set; }

        public WeightedItem(T item, float weight)
        {
            Item = item;
            Weight = weight;
        }
    }
}