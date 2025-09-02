using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace NUnit.Framework;

public class TestCaseDataDictionary : Dictionary<String, Object[]>
{
    public static readonly String TestCaseDataString = "TestCaseData";
    public static readonly String DescriptionString = "Description";
    public static readonly String CategoryString = "Category";
    public static readonly String ConstructorString = "Constructor";
    public static readonly String InitializorString = "Initializor";
    public static readonly String AccessorString = "Accessor";
    public static readonly String TestCaseIdString = "TestCaseId";
    public static readonly string EmptyString = "";
    public static readonly string SpaceString = " ";
    public TestCaseDataDictionary() : base() { }
    public TestCaseDataDictionary(String TestCaseElement, Object[] TestCaseData) => Add(TestCaseElement, TestCaseData);
    public TestCaseDataDictionary(Tuple<String, Object[]> TestCase) => Add(TestCase.Item1, TestCase.Item2);
    public TestCaseDataDictionary(List<Tuple<String, Object[]>> TestCases)
    {
        for (int index = 0; index < TestCases.Count; index++)
        {
            Add(TestCases[index].Item1, TestCases[index].Item2);
        }
    }
    public TestCaseDataDictionary(String[] TestCaseDescriptions, String[] TestCaseCategories, String[] TestCaseIds, TestCaseData[] TestCaseData)
    {
        int max = int.Max(TestCaseData.Length, int.Max(TestCaseIds.Length, int.Max(TestCaseCategories.Length, TestCaseDescriptions.Length)));
        if (TestCaseData.Length != max || TestCaseIds.Length != max || (TestCaseCategories.Length != max && TestCaseCategories.Length != 1) || TestCaseDescriptions.Length != max)
        {
            string message = "invalid combination of argument array lengths!  ";
            if (TestCaseData.Length != max) message += "(TestCaseData Length of " + TestCaseData.Length.ToString() + " with expected of " + max.ToString() + ")";
            if (TestCaseIds.Length != max) message += "(TestCaseIds Length of " + TestCaseIds.Length.ToString() + " with expected of " + max.ToString() + ")";
            if (TestCaseCategories.Length != max && TestCaseCategories.Length != 1) message += "(TestCaseCategories Length of " + TestCaseCategories.Length.ToString() + " with expected of " + max.ToString() + ")";
            if (TestCaseDescriptions.Length != max) message += "(TestCaseDescriptions Length of " + TestCaseDescriptions.Length.ToString() + " with expected of " + max.ToString() + ")";
            message += "Ids[";
            string sep = "";
            foreach (string id in TestCaseIds)
            {
                message += sep + " " + id;
                sep = ",";
            }
            message += "]";
            throw new InvalidArgumentException(message);
        }
        List<String> descriptions = [];
        List<String> categories = [];
        List<String> caseIds = [];
        List<TestCaseData> data = [];
        for (int index = 0; index < max; index++)
        {
            descriptions.Add(TestCaseDescriptions[index]);
            if (TestCaseCategories.Length > 1)
            {
                categories.Add(TestCaseCategories[index]);
            }
            else if (index == 0)
            {
                categories.Add(TestCaseCategories[index]);
            }
            caseIds.Add(TestCaseIds[index]);
            data.Add(TestCaseData[index]);
        }
        Add(DescriptionString, descriptions.ToArray<String>());
        Add(CategoryString, categories.ToArray<String>());
        Add(TestCaseIdString, caseIds.ToArray<String>());
        Add(TestCaseDataString, data.ToArray<TestCaseData>());
    }
}
