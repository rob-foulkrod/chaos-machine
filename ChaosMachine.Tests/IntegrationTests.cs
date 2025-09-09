using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace ChaosMachine.Tests;

public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public IntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task HomePage_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task PrivacyPage_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/Home/Privacy");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task ErrorPage_ReturnsSuccessStatusCode()
    {
        // Act
        var response = await _client.GetAsync("/Home/Error");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task HomePage_ContainsExpectedContentType()
    {
        // Act
        var response = await _client.GetAsync("/");

        // Assert
        Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType?.ToString());
    }
}