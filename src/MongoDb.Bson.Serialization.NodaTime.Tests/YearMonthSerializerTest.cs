using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class YearMonthSerializerTest
{
    static YearMonthSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new YearMonthSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var year = faker.Random.Int(1, 2024);
        var month = faker.Random.Int(1, 12);
        var yearMonth = new YearMonth(year, month);

        var serialized = yearMonth.ToJson();
        var deserialized = BsonSerializer.Deserialize<YearMonth>(serialized);

        deserialized.Should().Be(yearMonth);
    }
}