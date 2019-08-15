namespace HelloWorld.Common.Interfaces
{
    public interface ISettingsService
    {
        HelloWorldProvider Provider { get; }

        string OutputString { get; }
    }
}