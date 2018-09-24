namespace ISO_Robinson.Game
{
    abstract class Player
    {
        protected uint Strategy { get; set; }

        protected float TempResult { get; set; }

        public int[] ResultSet { get; set; }

        public int[] StrategicSet { get; set; }

        public uint SupposedStrategy { get; set; }

        public abstract void ChangeStrategy();
    }
}
