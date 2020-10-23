using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace NameMatcher
{
    public static class FileProcessor
    {
        public static List<User> GetSecondaryEmailForMatchingName(string firstFile, string secondFile)
        {
            var firstUsers = GetUsers(firstFile);
            var secondUsers = GetUsers(secondFile);

            return secondUsers.Intersect(firstUsers, new UserNameEqualityComparer()).ToList();
        }

        private static List<User> GetUsers(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csvReader.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                    return csvReader.GetRecords<User>().ToList();
                }
            }
        }
    }
}
