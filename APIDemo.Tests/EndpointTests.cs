using System.Net.Mime;
using System.Text;
using System.Text.Json;
using APIDemo.API.DTO;

namespace APIDemo.Tests;

[TestClass]
public class APITests
{
    [TestMethod]
    public async Task HealthTest()
    {
        await using var application = new TestWebApplicationFactory();
        using var client = application.CreateClient();

        var res = await client.GetAsync("/health");
        res.EnsureSuccessStatusCode();

        Assert.AreEqual(200, (int)res.StatusCode);
    }

    [TestMethod]
    public async Task CreateTodoItem()
    {
        await using var application = new TestWebApplicationFactory();
        using var client = application.CreateClient();

        var body = new NewTodoItem() { Title = "foo", Description = "bar" };
        var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, MediaTypeNames.Application.Json);
        var res = await client.PostAsync("/todo", content);

        res.EnsureSuccessStatusCode();
    }

    [TestMethod]
    public async Task CreateTodoItem_InvalidTitle_Returns400()
    {
        await using var application = new TestWebApplicationFactory();
        using var client = application.CreateClient();

        var body = new NewTodoItem() { Title = "", Description = "bar" };
        var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, MediaTypeNames.Application.Json);
        var res = await client.PostAsync("/todo", content);

        Assert.AreEqual(400, (int)res.StatusCode);
    }

    [TestMethod]
    public async Task CreateTodoItem_InvalidDescription_Returns400()
    {
        await using var application = new TestWebApplicationFactory();
        using var client = application.CreateClient();

        var body = new NewTodoItem() { Title = "foo", Description = "" };
        var content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, MediaTypeNames.Application.Json);
        var res = await client.PostAsync("/todo", content);

        Assert.AreEqual(400, (int)res.StatusCode);
    }

}