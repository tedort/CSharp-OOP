namespace Attributes
{
    [Documentation("MoreInfo")]
    public class Shape
    {
        [Documentation("MoreInfoMethod")]
        public virtual void Draw()
        {
            Console.WriteLine("I'm a shape!");
        }

        [Documentation("MoreInfoProp")]
        public int Size { get; set; }
    }
}
