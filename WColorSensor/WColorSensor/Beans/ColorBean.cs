namespace WColorSensor.Beans
{
    public class ColorBean
    {
        public short R { get; set; }

        public short G { get; set; }

        public short B { get; set; }

        public string Color { get; set; }

        public ColorBean(short r, short g, short b, string color)
        {
            R = r;
            G = g;
            B = b;
            Color = color;
        }
    }
}