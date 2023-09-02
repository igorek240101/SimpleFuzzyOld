using SimpleFuzzy.Abstract;

namespace SimpleFuzzy.AgeSets
{
    public class ZeroToOneHangred : IBaseSet
    {
        private byte[] array = new byte[101];
        private int index = 0;

        public ZeroToOneHangred()
        {
            for(int i = 0; i < array.Length; i++) array[i] = (byte)i;
        }

        public static string Name => "Целые числа от 0 до 100";

        public object Get() => array[index];
        
        public bool IsEnd() => index == array.Length;

        public void ToFirst() => index = 0;

        public void ToNext() => index++;
    }
}