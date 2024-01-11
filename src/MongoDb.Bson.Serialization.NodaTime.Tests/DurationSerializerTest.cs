using Bogus;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using NodaTime;
using FluentAssertions;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class DurationSerializerTest
{
    static DurationSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new DurationSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();
        var duration = Duration.FromSeconds(faker.Random.Int());

        var serialized = duration.ToJson();
        var deserialized = BsonSerializer.Deserialize<Duration>(serialized);

        deserialized.Should().Be(duration);
    }


    /*
    [Fact]
    public void ThrowsWhenValueIsInvalid()
    {
        Assert.Throws<FormatException>(() => BsonNodaTimeSerializer.Deserialize<Test>(new BsonDocument(new BsonElement("Duration", "bleh"))));
    }

    [Fact]
    public void CanParseNullable()
    {
        BsonNodaTimeSerializer.Deserialize<Test>(new BsonDocument(new BsonElement("DurationNullable", BsonNull.Value))).DurationNullable.Should().BeNull();
    }

    private class Test
    {
        public Duration Duration { get; set; }
        public Duration? DurationNullable { get; set; }
    }    }
*/
}