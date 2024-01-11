using Bogus;
using FluentAssertions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime.Tests;

public class OffsetSerializerTest
{
    static OffsetSerializerTest()
    {
        BsonSerializer.RegisterSerializer(new OffsetSerializer());
    }

    [Fact]
    public void Serialize_returns_expected_result()
    {
        var faker = new Faker();

        var offset = Offset.FromSeconds(faker.Random.Int(1, 500));

        var serialized = offset.ToJson();
        var deserialized = BsonSerializer.Deserialize<Offset>(serialized);

        deserialized.Should().Be(offset);
    }
}