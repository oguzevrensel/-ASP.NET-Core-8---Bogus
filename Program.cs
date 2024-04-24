using FakeData.Context;
using FakeData.Services;

class Program
{
    static void Main(string[] args)
    {
        using var context = new DataContext();
        var fakeDataGenerate = new FakeDataGenerate(context);

        fakeDataGenerate.GenerateAndSaveData();
    }
}