using SimpleFuzzy.Abstract;

namespace CatFuzzy
{
    public class CatSets : IBaseSet
    {
        private Cat[] array = new Cat[9];
        private int index = 0;

        public CatSets()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[i * 3 + j] = new Cat() 
                    { 
                        Mother = (CatColor)i,
                        Father = (CatColor)j,
                    };
                }
            }
        }

        public string Name => "Цветастые котики";

        public object Get() => array[index];

        public bool IsEnd() => index == array.Length;

        public void ToFirst() => index = 0;

        public void ToNext() => index++;
    }

    public class Cat
    {
        public CatColor Mother { get; set; }
        public CatColor Father { get; set; }

        public override string ToString()
            => Mother.ToString() + Father.ToString();
    }

    public enum CatColor
    {
        Black,
        Ginger,
        White
    }
}