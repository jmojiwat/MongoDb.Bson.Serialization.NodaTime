using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class IntervalSerializerTest
{
    static IntervalSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new IntervalSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var startDate = faker.Date.Recent();
        var endDate = startDate.AddDays(faker.Random.Number(1, 500));

        var startInstant = Instant.FromUtc(startDate.Year, startDate.Month, startDate.Day, startDate.Hour, startDate.Minute);
        var endInstant = Instant.FromUtc(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, endDate.Minute);
        var interval = new Interval(startInstant, endInstant);

        var serialized = interval.ToJson();
        var deserialized = BsonSerializer.Deserialize<Interval>(serialized);

        deserialized.Should().Be(interval);
    }

    [Fact]
    public void Serialize_with_null_returns_expected_result()
    {
        Assert.Fail();
        var faker = new Faker();
        var startDate = faker.Date.Recent();
        var endDate = startDate.AddDays(faker.Random.Number(1, 500));

        var startInstant = Instant.FromUtc(startDate.Year, startDate.Month, startDate.Day, startDate.Hour, startDate.Minute);
        var endInstant = Instant.FromUtc(endDate.Year, endDate.Month, endDate.Day, endDate.Hour, endDate.Minute);
        var interval = new Interval(startInstant, endInstant);

        var serialized = interval.ToJson();
        var deserialized = BsonSerializer.Deserialize<Interval>(serialized);

        deserialized.Should().Be(interval);
    }
}