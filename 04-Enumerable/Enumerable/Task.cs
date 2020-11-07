using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace EnumerableTask
{

    public class Task
    {

        /// <summary> Transforms all strings to uppercase</summary>
        /// <param name="data">source string sequence</param>
        /// <returns>
        ///   Returns sequence of source strings in uppercase
        /// </returns>
        /// <example>
        ///    {"a","b","c"} => { "A", "B", "C" }
        ///    { "A", "B", "C" } => { "A", "B", "C" }
        ///    { "a", "A", "", null } => { "A", "A", "", null }
        /// </example>
        public IEnumerable<string> GetUppercaseStrings(IEnumerable<string> data)
        {
            // TODO : Implement GetUppercaseStrings
            string[] arr = data.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i]?.ToUpper();
            }
            return arr;
        }

        /// <summary> Transforms an each string from sequence to its length</summary>
        /// <param name="data">source strings sequence</param>
        /// <returns>
        ///   Returns sequence of strings length
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   {"a","aa","aaa" } => { 1, 2, 3 }
        ///   {"aa","bb","cc", "", "  ", null } => { 2, 2, 2, 0, 2, 0 }
        /// </example>
        public IEnumerable<int> GetStringsLength(IEnumerable<string> data)
        {
            // TODO : Implement GetStringsLength
            List<int> list = new List<int>(data.Count());
            foreach (var item in data)
            {
                list.Add(item == null ? 0 : item.Length);
            }
            return list;
        }

        /// <summary>Transforms int sequence to its square sequence, f(x) = x * x </summary>
        /// <param name="data">source int sequence</param>
        /// <returns>
        ///   Returns sequence of squared items
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2, 3, 4, 5 } => { 1, 4, 9, 16, 25 }
        ///   { -1, -2, -3, -4, -5 } => { 1, 4, 9, 16, 25 }
        /// </example>
        public IEnumerable<long> GetSquareSequence(IEnumerable<int> data)
        {
            // TODO : Implement GetSquareSequence
            List<long> list = new List<long>(data.Count());
            foreach (var item in data)
            {
                list.Add((long)item * item);
            }
            return list;
        }

        /// <summary>Transforms int sequence to its moving sum sequence, 
        ///          f[n] = x[0] + x[1] + x[2] +...+ x[n] 
        ///       or f[n] = f[n-1] + x[n]   
        /// </summary>
        /// <param name="data">source int sequence</param>
        /// <returns>
        ///   Returns sequence of sum of all source items with less or equals index
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 1, 1, 1 } => { 1, 2, 3, 4 }
        ///   { 5, 5, 5, 5 } => { 5, 10, 15, 20 }
        ///   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } => { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55 }
        ///   { 1, -1, 1, -1, -1 } => { 1, 0, 1, 0, 1 }
        /// </example>
        public IEnumerable<long> GetMovingSumSequence(IEnumerable<int> data)
        {
            // TODO : Implement GetMovingSumSequence
            long[] arr = new long[data.Count()];
            data.ToArray().CopyTo(arr, 0);
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] += arr[i - 1];
            }
            return arr;
        }


        /// <summary> Filters a string sequence by a prefix value (case insensitive)</summary>
        /// <param name="data">source string sequence</param>
        /// <param name="prefix">prefix value to filter</param>
        /// <returns>
        ///  Returns items from data that started with required prefix (case insensitive)
        /// </returns>
        /// <exception cref="System.ArgumentNullException">prefix is null</exception>
        /// <example>
        ///  { "aaa", "bbbb", "ccc", null }, prefix="b"  =>  { "bbbb" }
        ///  { "aaa", "bbbb", "ccc", null }, prefix="B"  =>  { "bbbb" }
        ///  { "a","b","c" }, prefix="D"  => { }
        ///  { "a","b","c" }, prefix=""   => { "a","b","c" }
        ///  { "a","b","c", null }, prefix=""   => { "a","b","c" }
        ///  { "a","b","c" }, prefix=null => exception
        /// </example>
        public IEnumerable<string> GetPrefixItems(IEnumerable<string> data, string prefix)
        {
            // TODO : Implement GetPrefixItems
            if (prefix == null)
                throw new ArgumentNullException();
            List<string> list = new List<string>();
            foreach (var item in data)
            {
                if (item != null && item.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                    list.Add(item);
            }
            return list;
        }

        /// <summary> Returns every second item from source sequence</summary>
        /// <typeparam name="T">the type of the elements of data</typeparam>
        /// <param name="data">source sequence</param>
        /// <returns>Returns a subsequence that consists of every second item from source sequence</returns>
        /// <example>
        ///  { 1,2,3,4,5,6,7,8,9,10 } => { 2,4,6,8,10 }
        ///  { "a","b","c" , null } => { "b", null }
        ///  { "a" } => { }
        /// </example>
        public IEnumerable<T> GetEvenItems<T>(IEnumerable<T> data)
        {
            // TODO : Implement GetEvenItems
            List<T> list = new List<T>(data.Count() / 2);
            for (int i = 1; i < data.Count(); i += 2)
            {
                list.Add(data.ToArray()[i]);
            }
            return list;
        }

        /// <summary> Propagate every item in sequence its position times</summary>
        /// <typeparam name="T">the type of the elements of data</typeparam>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns a sequence that consists of: one first item, two second items, tree third items etc. 
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1 } => { 1 }
        ///   { "a","b" } => { "a", "b","b" }
        ///   { "a", "b", "c", null } => { "a", "b","b", "c","c","c", null,null,null,null }
        ///   { 1,2,3,4,5} => { 1, 2,2, 3,3,3, 4,4,4,4, 5,5,5,5,5 }
        /// </example>
        public IEnumerable<T> PropagateItemsByPositionIndex<T>(IEnumerable<T> data)
        {
            // TODO : Implement PropagateItemsByPositionIndex
            int listSize = data.Count();
            int counter = 0;
            for (int i = 0; i < data.Count(); i++)
            {
                listSize += listSize - 1;

            }
            List<T> list = new List<T>(listSize);
            foreach (var item in data)
            {
                counter++;
                for (int i = 0; i < counter; i++)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>Finds all used char in string sequence</summary>
        /// <param name="data">source string sequence</param>
        /// <returns>
        ///   Returns set of chars used in string sequence.
        ///   Order of result does not matter.
        /// </returns>
        /// <example>
        ///   { "aaa", "bbb", "cccc", "abc" } => { 'a', 'b', 'c' } or { 'c', 'b', 'a' }
        ///   { " ", null, "   ", "" } => { ' ' }
        ///   { "", null } => { }
        ///   { } => { }
        /// </example>
        public IEnumerable<char> GetUsedChars(IEnumerable<string> data)
        {
            // TODO : Implement GetUsedChars
            List<char> list = new List<char>();
            foreach (string item in data)
            {
                if (string.IsNullOrEmpty(item))
                    continue;
                foreach (char item2 in item)
                {
                    if (!list.Contains(item2))
                        list.Add(item2);
                }
            }
            return list;
        }


        /// <summary> Converts a source sequence to a string</summary>
        /// <typeparam name="T">the type of the elements of data</typeparam>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns a string respresentation of source sequence 
        /// </returns>
        /// <example>
        ///   { } => ""
        ///   { 1,2,3 } => "1,2,3"
        ///   { "a", "b", "c", null, ""} => "a,b,c,null,"
        ///   { "", "" } => ","
        /// </example>
        public string GetStringOfSequence<T>(IEnumerable<T> data)
        {
            // TODO : Implement GetStringOfSequence
            string str = "";
            foreach (var item in data)
            {
                if (item == null)
                    str += "null,";
                else
                    str += item.ToString() + ",";
            }
            if (str != "")
                str = str.Remove(str.Length - 1);
            return str;
        }

        /// <summary> Finds the 3 largest numbers from a sequence</summary>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns the 3 largest numbers from a sequence
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2 } => { 2, 1 }
        ///   { 1, 2, 3 } => { 3, 2, 1 }
        ///   { 1,2,3,4,5,6,7,8,9,10 } => { 10, 9, 8 }
        ///   { 10, 10, 10, 10 } => { 10, 10, 10 }
        /// </example>
        public IEnumerable<int> Get3TopItems(IEnumerable<int> data)
        {
            // TODO : Implement Get3TopItems
            data = data.OrderByDescending(a => a);
            if (data.Count() < 4)
                return data;
            return data.Take(3);
        }

        /// <summary> Calculates the count of numbers that are greater then 10</summary>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns the number of items that are > 10
        /// </returns>
        /// <example>
        ///   { } => 0
        ///   { 1, 2, 10 } => 0
        ///   { 1, 2, 3, 11 } => 1
        ///   { 1, 20, 30, 40 } => 3
        /// </example>
        public int GetCountOfGreaterThen10(IEnumerable<int> data)
        {
            // TODO : Implement GetCountOfGreaterThen10

            int counter = 0;
            foreach (var item in data)
            {
                if (item > 10)
                    counter++;
            }
            return counter;
        }


        /// <summary> Find the first string that contains "first" (case insensitive search)</summary>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns the first string that contains "first" or null if such an item does not found.
        /// </returns>
        /// <example>
        ///   { "a", "b", null} => null
        ///   { "a", "IT IS FIRST", "first item", "I am really first!" } => "IT IS FIRST"
        ///   { } => null
        /// </example>
        public string GetFirstContainsFirst(IEnumerable<string> data)
        {
            // TODO : Implement GetFirstContainsFirst
            foreach (var item in data)
            {
                if (item?.IndexOf("first", StringComparison.OrdinalIgnoreCase) > 0)
                {
                    return item;
                }

            }
            return null;
        }

        /// <summary> Counts the number of unique strings with length=3 </summary>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns the number of unique strings with length=3.
        /// </returns>
        /// <example>
        ///   { "a", "b", null, "aaa"} => 1    ("aaa")
        ///   { "a", "bbb", null, "", "ccc" } => 2  ("bbb","ccc")
        ///   { "aaa", "aaa", "aaa", "bbb" } => 2   ("aaa", "bbb") 
        ///   { } => 0
        /// </example>
        public int GetCountOfStringsWithLengthEqualsTo3(IEnumerable<string> data)
        {
            // TODO : Implement GetCountOfStringsWithLengthEqualsTo3
            HashSet<string> hash = new HashSet<string>();
            foreach (var item in data)
            {
                if (item == null || item.Length != 3)
                    continue;
                hash.Add(item);
            }
            return hash.Count();
        }

        /// <summary> Counts the number of each strings in sequence </summary>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns the list of strings and number of occurence for each string.
        /// </returns>
        /// <example>
        ///   { "a", "b", "a", "aa", "b"} => { ("a",2), ("b",2), ("aa",1) }    
        ///   { "a", "a", null, "", "ccc", "" } => { ("a",2), (null,1), ("",2), ("ccc",1) }
        ///   { "aaa", "aaa", "aaa" } =>  { ("aaa", 3) } 
        ///   { } => { }
        /// </example>
        public IEnumerable<Tuple<string, int>> GetCountOfStrings(IEnumerable<string> data)
        {
            // TODO : Implement GetCountOfStrings
            List<Tuple<string, int>> tuples = new List<Tuple<string, int>>();
            List<string> str = new List<string>();
            List<int> counters = new List<int>();
            foreach (var item in data)
            {
                if (str.Contains(item))
                    counters[str.IndexOf(item)]++;
                else
                {
                    str.Add(item);
                    counters.Add(1);
                }
            }
            for (int i = 0; i < counters.Count(); i++)
            {
                tuples.Add(new Tuple<string, int>(str[i], counters[i]));
            }
            return tuples;
        }

        /// <summary> Counts the number of strings with max length in sequence </summary>
        /// <param name="data">source sequence</param>
        /// <returns>
        ///   Returns the number of strings with max length. (Assuming that null has Length=0).
        /// </returns>
        /// <example>
        ///   { "a", "b", "a", "aa", "b"} => 1 
        ///   { "a", "aaa", null, "", "ccc", "" } => 2   
        ///   { "aaa", "aaa", "aaa" } =>  3
        ///   { "", null, "", null } => 4
        ///   { } => { }
        /// </example>
        public int GetCountOfStringsWithMaxLength(IEnumerable<string> data)
        {
            // TODO : Implement GetCountOfStringsWithMaxLength
            int counter = 0;
            int maxValue = 0;

            foreach (string item in data)
            {
                int curentValue = string.IsNullOrEmpty(item) ? 0 : item.Length;
                if (curentValue > maxValue)
                {
                    maxValue = curentValue;
                }

            }
            foreach (var item in data)
            {
                if (item != null && item.Length == maxValue)
                    counter++;
                else if (maxValue == 0)
                    counter++;
            }

            return counter;
        }





        /// <summary> Counts the digit chars in a string</summary>
        /// <param name="data">source string</param>
        /// <returns>
        ///   Returns number of digit chars in the string
        /// </returns>
        /// <exception cref="System.ArgumentNullException">data is null</exception>
        /// <example>
        ///    "aaaa" => 0
        ///    "1234" => 4
        ///    "A1*B2" => 2
        ///    "" => 0
        ///    null => exception
        /// </example>
        public int GetDigitCharsCount(string data)
        {
            // TODO : Implement GetDigitCharsCount
            int countDigit = 0;
            if (data == null)
                throw new ArgumentNullException();
            foreach (char item in data)
            {
                if (char.IsDigit(item))
                    countDigit++;
            }
            return countDigit;
        }



        /// <summary>Counts the system log events of required type</summary>
        /// <param name="value">the type of log event (Error, Event, Information etc)</param>
        /// <returns>
        ///   Returns the number of System log entries of specified type
        /// </returns>
        public int GetSpecificEventEntriesCount(EventLogEntryType value)
        {
            // TODO : Implement GetSpecificEventEntriesCount
            EventLogEntryCollection systemEvents = (new EventLog("System", ".")).Entries;
            int counter = 0;
            foreach (EventLogEntry item in systemEvents)
            {
                if (item.EntryType == value)
                    counter++;
            }
            return counter;
        }


        /// <summary> Finds all exported types names which implement IEnumerable</summary>
        /// <param name="assembly">the assembly to search</param>
        /// <returns>
        ///   Returns the names list of exported types implemented IEnumerable from specified assembly
        /// </returns>
        /// <exception cref="System.ArgumentNullException">assembly is null</exception>
        /// <example>
        ///    mscorlib => { "ApplicationTrustCollection","Array","ArrayList","AuthorizationRuleCollection",
        ///                  "BaseChannelObjectWithProperties", ... }
        ///    
        /// </example>
        public IEnumerable<string> GetIEnumerableTypesNames(Assembly assembly)
        {
            // TODO : Implement GetIEnumerableTypesNames
            throw new NotImplementedException();

        }

        /// <summary>Calculates sales sum by quarter</summary>
        /// <param name="sales">the source sales data : Item1 is sales date, Item2 is amount</param>
        /// <returns>
        ///     Returns array of sales sum by quarters, 
        ///     result[0] is sales sum for Q1, result[1] is sales sum for Q2 etc  
        /// </returns>
        /// <example>
        ///    {} => { 0, 0, 0, 0}
        ///    {(1/1/2010, 10)  , (2/2/2010, 10), (3/3/2010, 10) } => { 30, 0, 0, 0 }
        ///    {(1/1/2010, 10)  , (4/4/2010, 10), (10/10/2010, 10) } => { 10, 10, 0, 10 }
        /// </example>
        public int[] GetQuarterSales(IEnumerable<Tuple<DateTime, int>> sales)
        {
            // TODO : Implement GetQuarterSales
            int[] sumSales = new int[4];
            foreach (var item in sales)
            {
                int dec = (item.Item1.Month - 1) / 3;
                sumSales[dec] += item.Item2;
            }
            return sumSales;
        }


        /// <summary> Sorts string by length and alphabet </summary>
        /// <param name="data">the source data</param>
        /// <returns>
        /// Returns sequence of strings sorted by length and alphabet
        /// </returns>
        /// <example>
        ///  {} => {}
        ///  {"c","b","a"} => {"a","b","c"}
        ///  {"c","cc","b","bb","a,"aa"} => {"a","b","c","aa","bb","cc"}
        /// </example>
        public IEnumerable<string> SortStringsByLengthAndAlphabet(IEnumerable<string> data)
        {
            // TODO : Implement SortStringsByLengthAndAlphabet
            return data.OrderBy(a => a.Length).ThenBy(a => a);
        }

        /// <summary> Finds all missing digits </summary>
        /// <param name="data">the source data</param>
        /// <returns>
        /// Return all digits that are not in the string sequence
        /// </returns>
        /// <example>
        ///   {} => {'0','1','2','3','4','5','6','7','8','9'}
        ///   {"aaa","a1","b","c2","d","e3","f01234"} => {'5','6','7','8','9'}
        ///   {"a","b","c","9876543210"} => {}
        /// </example>
        public IEnumerable<char> GetMissingDigits(IEnumerable<string> data)
        {
            // TODO : Implement GetMissingDigits
            List<char> list = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', };
            if (data.Count() == 0)
            {
                return list;
            }
            else
            {
                foreach (string item in data)
                {

                    foreach (char ch in item)
                    {
                        if (char.IsDigit(ch))
                            list.Remove(ch);
                    }
                }
                return list;
            }
        }


        /// <summary> Sorts digit names </summary>
        /// <param name="data">the source data</param>
        /// <returns>
        /// Return all digit names sorted by numeric order
        /// </returns>
        /// <example>
        ///   {} => {}
        ///   {"nine","one"} => {"one","nine"}
        ///   {"one","two","three"} => {"one","two","three"}
        ///   {"nine","eight","nine","eight"} => {"eight","eight","nine","nine"}
        ///   {"one","one","one","zero"} => {"zero","one","one","one"}
        /// </example>
        public IEnumerable<string> SortDigitNamesByNumericOrder(IEnumerable<string> data)
        {
            // TODO : Implement SortDigitNamesByNumericOrder

            return data.OrderBy(x => Array.IndexOf(new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" }, x));

        }

        /// <summary> Combines numbers and fruits </summary>
        /// <param name="numbers">string sequience of numbers</param>
        /// <param name="fruits">string sequence of fruits</param>
        /// <returns>
        ///   Returns new sequence of merged number and fruit items
        /// </returns>
        /// <example>
        ///  {"one","two","three"}, {"apple", "bananas","pineapples"} => {"one apple","two bananas","three pineapples"}
        ///  {"one"}, {"apple", "bananas","pineapples"} => {"one apple"}
        ///  {"one","two","three"}, {"apple", "bananas" } => {"one apple","two bananas"}
        ///  {"one","two","three"}, { } => { }
        ///  { }, {"apple", "bananas" } => { }
        /// </example>
        public IEnumerable<string> CombineNumbersAndFruits(IEnumerable<string> numbers, IEnumerable<string> fruits)
        {
            // TODO : Implement CombinesNumbersAndFruits
            List<string> list = new List<string>();

            for (int i = 0, j = 0; i < fruits.Count() && j < numbers.Count(); j++, i++)
            {

                if (!string.IsNullOrEmpty(numbers.ElementAt(j)) && !string.IsNullOrEmpty(fruits.ElementAt(i)))
                    list.Add(numbers.ElementAt(j) + " " + fruits.ElementAt(i));
            }
            return list;
        }


        /// <summary> Finds all chars that are common for all words </summary>
        /// <param name="data">sequence of words</param>
        /// <returns>
        ///  Returns set of chars that are occured in all words (sorted in alphabetical order)
        /// </returns>
        /// <example>
        ///   {"ab","ac","ad"} => {"a"}
        ///   {"a","b","c"} => { }
        ///   {"a","aa","aaa"} => {"a"}
        ///   {"ab","ba","aabb","baba"} => {"a","b"}
        /// </example>
        public IEnumerable<char> GetCommonChars(IEnumerable<string> data)
        {
            // TODO : Implement GetCommonChars
            if (data.Count() == 0)
                return string.Empty;


            throw new NotImplementedException();
        }

        /// <summary> Calculates sum of all integers from object array </summary>
        /// <param name="data">source data</param>
        /// <returns>
        ///    Returns the sum of all inetegers from object array
        /// </returns>
        /// <example>
        ///    { 1, true, "a","b", false, 1 } => 2
        ///    { true, false } => 0
        ///    { 10, "ten", 10 } => 20 
        ///    { } => 0
        /// </example>
        public int GetSumOfAllInts(object[] data)
        {
            // TODO : Implement GetSumOfAllInts
            int numb = 0;
            foreach (var item in data)
            {
                if (item is int)
                    numb += (int)item;
            }
            return numb;
        }


        /// <summary> Finds all strings in array of objects</summary>
        /// <param name="data">source array</param>
        /// <returns>
        ///   Return subsequence of string from source array of objects
        /// </returns>
        /// <example>
        ///   { "a", 1, 2, null, "b", true, 4.5, "c" } => { "a", "b", "c" }
        ///   { "a", "b", "c" } => { "a", "b", "c" }
        ///   { 1,2,3, true, false } => { }
        ///   { } => { }
        /// </example>
        public IEnumerable<string> GetStringsOnly(object[] data)
        {
            // TODO : Implement GetStringsOnly
            List<string> list = new List<string>();
            foreach (var item in data)
            {
                if (item is string)
                    list.Add((string)item);
            }
            return list;
        }

        /// <summary> Calculates the total length of strings</summary>
        /// <param name="data">source string sequence</param>
        /// <returns>
        ///   Return sum of length of all strings
        /// </returns>
        /// <example>
        ///   {"a","b","c","d","e","f"} => 6
        ///   { "a","aa","aaa" } => 6
        ///   { "1234567890" } => 10
        ///   { null, "", "a" } => 1
        ///   { null } => 0
        ///   { } => 0
        /// </example>
        public int GetTotalStringsLength(IEnumerable<string> data)
        {
            // TODO : Implement GetTotalStringsLength
            int strSize = 0;
            foreach (var item in data)
            {
                if (!string.IsNullOrEmpty(item))
                    strSize += item.Length;
            }
            return strSize;
        }

        /// <summary> Determines whether sequence has null elements</summary>
        /// <param name="data">source string sequence</param>
        /// <returns>
        ///  true if the source sequence contains null elements; otherwise, false.
        /// </returns>
        /// <example>
        ///   { "a", "b", "c", "d", "e", "f" } => false
        ///   { "a", "aa", "aaa", null } => true
        ///   { "" } => false
        ///   { null, null, null } => true
        ///   { } => false
        /// </example>
        public bool IsSequenceHasNulls(IEnumerable<string> data)
        {
            // TODO : Implement IsSequenceHasNulls
            bool check = false;
            foreach (var item in data)
            {
                if (item is null)
                    check = true;

            }
            return check;
        }

        /// <summary> Determines whether all strings in sequence are uppercase</summary>
        /// <param name="data">source string sequence</param>
        /// <returns>
        ///  true if all strings from source sequence are uppercase; otherwise, false.
        /// </returns>
        /// <example>
        ///   { "A", "B", "C", "D", "E", "F" } => true
        ///   { "AA", "AA", "AAA", "AAAa" } => false
        ///   { "" } => false
        ///   { } => false
        /// </example>
        public bool IsAllStringsAreUppercase(IEnumerable<string> data)
        {
            // TODO : Implement IsAllStringsAreUppercase
            bool check = true;
            if (data.Count() == 0)
                check = false;
            foreach (var item in data)
            {
                if (item == "")
                    check = false;
                foreach (var ch in item)
                {

                    if (char.IsLower(ch))
                        check = false;
                }
            }
            return check;
        }

        /// <summary> Finds first subsequence of negative integers </summary>
        /// <param name="data">source integer sequence</param>
        /// <returns>
        ///   Returns the first subsequence of negative integers from source
        /// </returns>
        /// <example>
        ///    { -2, -1 , 0, 1, 2 } => { -2, -1 }
        ///    { 2, 1, 0, -1, -2 } => { -1, -2 }
        ///    { 1, 1, 1, -1, -1, -1, 0, 0, 0, -2, -2, -2 } => { -1, -1, -1 }
        ///    { -1 , 0, -2 } => { -1 }
        ///    { 1, 2, 3 } => { }
        ///    { } => { }
        /// </example>
        public IEnumerable<int> GetFirstNegativeSubsequence(IEnumerable<int> data)
        {
            // TODO : Implement GetFirstNegativeSubsequence
            List<int> list = new List<int>();
            bool findNegative = false;
            foreach (var item in data)
            {
                if (item < 0)
                    findNegative = true;
                list.Add(item);
                continue;
            }
            if (findNegative)
                return list;
            return list;
        }


        /// <summary> 
        /// Compares two numeric sequences
        /// </summary>
        /// <param name="integers">sequence of integers</param>
        /// <param name="doubles">sequence of doubles</param>
        /// <returns>
        /// true if integers are equals doubles; otherwise, false.
        /// </returns>
        /// <example>
        /// { 1,2,3 } , { 1.0, 2.0, 3.0 } => true
        /// { 0,0,0 } , { 1.0, 2.0, 3.0 } => false
        /// { 3,2,1 } , { 1.0, 2.0, 3.0 } => false
        /// { -10 } => { -10.0 } => true
        /// </example>
        public bool AreNumericListsEqual(IEnumerable<int> integers, IEnumerable<double> doubles)
        {
            // TODO : Implement AreNumericListsEqual
            int sum = 0;
            for (int i = 0, j = 0; i < integers.Count() && j < doubles.Count(); j++, i++)
            {
                if (integers.ElementAt(i) == doubles.ElementAt(j))
                    sum++;
            }
            if (sum == integers.Count())
                return true;
            return false;
        }

        /// <summary>
        /// Finds the next after specified version from the list 
        /// </summary>
        /// <param name="versions">source list of versions</param>
        /// <param name="currentVersion">specified version</param>
        /// <returns>
        ///   Returns the next after specified version from the list; otherwise, null.
        /// </returns>
        /// <example>
        ///    { "1.1", "1.2", "1.5", "2.0" }, "1.1" => "1.2"
        ///    { "1.1", "1.2", "1.5", "2.0" }, "1.2" => "1.5"
        ///    { "1.1", "1.2", "1.5", "2.0" }, "1.4" => null
        ///    { "1.1", "1.2", "1.5", "2.0" }, "2.0" => null
        /// </example>
        public string GetNextVersionFromList(IEnumerable<string> versions, string currentVersion)
        {
            // TODO : Implement GetNextVersionFromList

            string str = null;
            for (int i = 0; i < versions.Count(); i++)
            {
                if ((currentVersion == versions.ElementAt(i)) && i + 1 < versions.Count())
                {
                    str = versions.ElementAt(i + 1);
                    break;
                }
            }
            return str;
        }

        /// <summary>
        ///  Calcuates the sum of two vectors:
        ///  (x1, x2, ..., xn) + (y1, y2, ..., yn) = (x1+y1, x2+y2, ..., xn+yn)
        /// </summary>
        /// <param name="vector1">source vector 1</param>
        /// <param name="vector2">source vector 2</param>
        /// <returns>
        ///  Returns the sum of two vectors
        /// </returns>
        /// <example>
        ///   { 1, 2, 3 } + { 10, 20, 30 } => { 11, 22, 33 }
        ///   { 1, 1, 1 } + { -1, -1, -1 } => { 0, 0, 0 }
        /// </example>
        public IEnumerable<int> GetSumOfVectors(IEnumerable<int> vector1, IEnumerable<int> vector2)
        {
            // TODO : Implement GetSumOfVectors
            List<int> list = new List<int>();
            for (int i = 0; i < vector1.Count(); i++)
            {
                list.Add(vector1.ElementAt(i) + vector2.ElementAt(i));
            }
            return list;
        }

        /// <summary>
        ///  Calcuates the product of two vectors:
        ///  (x1, x2, ..., xn) + (y1, y2, ..., yn) = x1*y1 + x2*y2 + ... + xn*yn
        /// </summary>
        /// <param name="vector1">source vector 1</param>
        /// <param name="vector2">source vector 2</param>
        /// <returns>
        ///  Returns the product of two vectors
        /// </returns>
        /// <example>
        ///   { 1, 2, 3 } * { 1, 2, 3 } => 1*1 + 2*2 + 3*3 = 14
        ///   { 1, 1, 1 } * { -1, -1, -1 } => 1*-1 + 1*-1 + 1*-1 = -3
        ///   { 1, 1, 1 } * { 0, 0, 0 } => 1*0 + 1*0 +1*0 = 0
        /// </example>
        public int GetProductOfVectors(IEnumerable<int> vector1, IEnumerable<int> vector2)
        {
            // TODO : Implement GetProductOfVectors
            int result = 0;
            for (int i = 0; i < vector1.Count(); i++)
            {
                result += (vector1.ElementAt(i) * vector2.ElementAt(i));
            }
            return result;
        }


        /// <summary>
        ///   Finds all boy+girl pair
        /// </summary>
        /// <param name="boys">boys' names</param>
        /// <param name="girls">girls' names</param>
        /// <returns>
        ///   Returns all combination of boys and girls names 
        /// </returns>
        /// <example>
        ///  {"John", "Josh", "Jacob" }, {"Ann", "Alice"} => {"John+Ann","John+Alice", "Josh+Ann","Josh+Alice", "Jacob+Ann", "Jacob+Alice" }
        ///  {"John"}, {"Alice"} => {"John+Alice"}
        ///  {"John"}, { } => { }
        ///  { }, {"Alice"} => { }
        /// </example>
        public IEnumerable<string> GetAllPairs(IEnumerable<string> boys, IEnumerable<string> girls)
        {
            // TODO : Implement GetAllPairs
            List<string> list = new List<string>();

            for (int i = 0; i < boys.Count(); i++)
            {
                for (int j = 0; j < girls.Count(); j++)
                {
                    if (!string.IsNullOrEmpty(boys.ElementAt(i)) && !string.IsNullOrEmpty(girls.ElementAt(j)))
                        list.Add(boys.ElementAt(i) + "+" + girls.ElementAt(j));
                }

            }
            return list;
        }


        /// <summary>
        ///   Calculates the average of all double values from object collection
        /// </summary>
        /// <param name="data">the source sequence</param>
        /// <returns>
        ///  Returns the average of all double values
        /// </returns>
        /// <example>
        ///  { 1.0, 2.0, null, "a" } => 1.5
        ///  { "1.0", "2.0", "3.0" } => 0.0  (no double values, strings only)
        ///  { null, 1.0, true } => 1.0
        ///  { } => 0.0
        /// </example>
        public double GetAverageOfDoubleValues(IEnumerable<object> data)
        {
            // TODO : Implement GetAverageOfDoubleValues
            double result = 0.0;
            List<double> list = new List<double>();
            foreach (var item in data)
            {
                if (item is double)
                {
                    list.Add((double)item);

                }

            }
            foreach (var item in list)
            {
                result += item;
            }
            if (list.Count > 0)
                result /= list.Count();
            return result;
        }

    }


}
