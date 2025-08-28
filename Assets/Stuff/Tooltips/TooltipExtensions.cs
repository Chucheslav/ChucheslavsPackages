using System;

namespace UITools.Tooltips
{
    public static class TooltipExtensions
    {
        public static string IDToDesc(this string ID)
        {
            return ID.InsertString("desc");
        }

        public static string IDToName(this string ID)
        {
            return ID.InsertString("name");
        }

        private static string InsertString(this string source, string toInsert)
        {
            if (string.IsNullOrEmpty(source)) return "";
            string[] parts = source.Split(new[] {'_'});
            Array.Resize(ref parts, parts.Length +1);

            parts[parts.Length - 1] = parts[parts.Length - 2];
            parts[parts.Length - 2] = toInsert;

            return string.Join("_", parts);
        }
    }
}
