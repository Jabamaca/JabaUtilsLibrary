using System.Collections.Generic;
using System.Text.Json;

namespace JabaUtilsLibrary.Data {

    public static class DictionaryUtils {

        #region Methods

        private static bool CheckSimilarContents<K, V> (Dictionary<K, V> dict1, Dictionary<K, V> dict2, bool strict) {
            foreach (KeyValuePair<K, V> kvp1 in dict1) {

                // Try get value of common key.
                if (dict2.TryGetValue (kvp1.Key, out V value2)) {
                    V value1 = kvp1.Value;

                    // Check NULL equality.
                    if (value1 == null && value2 == null)
                        continue;
                    else if (value1 == null || value2 == null)
                        return false;

                    // Check value equality.
                    if (!value1.Equals (value2))
                        return false;

                } else {
                    // Current key from Dictionary 1 not found in Dictionary 2.
                    if (!strict && kvp1.Value == null)
                        continue;

                    return false;

                }
            }

            return true;
        }

        public static bool CheckStrictEquals<K, V> (Dictionary<K, V> dict1, Dictionary<K, V> dict2) {
            // Check dictionary content count.
            if (dict1.Count != dict2.Count)
                return false;

            return CheckSimilarContents (dict1, dict2, strict: true);
        }

        public static bool CheckNonStrictEquals<K, V> (Dictionary<K, V> dict1, Dictionary<K, V> dict2) {
            return CheckSimilarContents (dict1, dict2, strict: false)
                && CheckSimilarContents (dict2, dict1, strict: false);
        }

        public static string DictToJsonString<K, V> (Dictionary<K, V> dict) {
            string returnValue = "{";

            bool firstValue = true;
            foreach (var kvp in dict) {
                // Comma separator.
                if (firstValue) {
                    firstValue = false;
                } else {
                    returnValue += ", ";
                }

                string serializedKey = JsonSerializer.Serialize (kvp.Key);
                string serializedValue = JsonSerializer.Serialize (kvp.Value);
                returnValue += "\"" + serializedKey + "\":\"" + serializedValue + "\"";
            }

            returnValue += "}";

            return returnValue;
        }

        #endregion

    }

}