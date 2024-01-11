using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class ZonedDateTimeSerializerTest
{
    static ZonedDateTimeSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new ZonedDateTimeSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var date = faker.Date.Recent();

        var instant = Instant.FromUtc(date.Year, date.Month, date.Day, date.Hour, date.Minute);
        var zone = DateTimeZone.Utc;

        var zonedDateTime = new ZonedDateTime(instant, zone);

        var serialized = zonedDateTime.ToJson();
        var deserialized = BsonSerializer.Deserialize<ZonedDateTime>(serialized);

        deserialized.Should().Be(zonedDateTime);
    }
}