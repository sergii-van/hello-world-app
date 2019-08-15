namespace HelloWorld.Common.Interfaces
{
    public interface IHelloWorldFactory
    {
        IHelloWorldProvider GetProvider(HelloWorldProvider provider);
    }
}