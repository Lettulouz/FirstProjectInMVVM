using System.Collections.Generic;


namespace Projekt_v0._04.GlobalFunctions
{
    public class AddToListStringClass
    {
        public static void AddToListString(List<string> listToFill, params string[] content)
        {
            for (int i = 0; i < content.Length; i++)
            {
                listToFill.Add(content[i]);
            }
        }
    }

}