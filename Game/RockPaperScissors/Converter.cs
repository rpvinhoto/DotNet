using Newtonsoft.Json;

namespace RockPaperScissors
{
    public static class Converter
    {
        public static string[] ToArrayString(string value1, string value2)
        {
            return new string[] { value1, value2 };
        }

        public static string[][] ToTwoArrayString(string value)
        {
            return JsonConvert.DeserializeObject<string[][]>(value);
        }

        public static string[][][][] ToFourArrayString(string value)
        {
            return JsonConvert.DeserializeObject<string[][][][]>(value);
        }

        public static string ToString(string[] value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}