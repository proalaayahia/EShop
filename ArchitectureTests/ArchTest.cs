using FluentAssertions;
using NetArchTest.Rules;

namespace ArchitectureTests;

public class ArchTest
{
    private const string DomainNameSpace = "EShop.Domain";
    private const string ApplicationNameSpace = "EShop.Application";
    private const string InfrastructureNameSpace = "EShop.Infrastructure";
    private const string PresentationNameSpace = "EShop.Presentation";
    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        //arrange
        var assembly = typeof(EShop.Domain.AssemblyReference).Assembly;
        var otherProjects = new[] { ApplicationNameSpace, InfrastructureNameSpace, PresentationNameSpace };
        //act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAll(otherProjects)
            .GetResult();
        //assert
        testResult.IsSuccessful.Should().BeTrue();
    }
    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        //arrange
        var assembly = typeof(EShop.Application.AssemblyReference).Assembly;
        var otherProjects = new[] { InfrastructureNameSpace, PresentationNameSpace };
        //act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        //assert
        testResult.IsSuccessful.Should().BeTrue();
    }
    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        //arrange
        var assembly = typeof(EShop.Infrastructure.AssemblyReference).Assembly;
        var otherProjects = new[] { PresentationNameSpace };
        //act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        //assert
        testResult.IsSuccessful.Should().BeTrue();
    }
    [Fact]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        //arrange
        var assembly = typeof(EShop.Presentation.AssemblyReference).Assembly;
        var otherProjects = new[] { InfrastructureNameSpace, DomainNameSpace };
        //act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();
        //assert
        testResult.IsSuccessful.Should().BeTrue();
    }
}
