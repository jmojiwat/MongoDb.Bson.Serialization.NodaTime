using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class DurationSerializer : SerializerBase<Duration>
{
    public override Duration Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) => 
        DurationPattern.Roundtrip.Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Duration value) => 
        context.Writer.WriteString(DurationPattern.Roundtrip.Format(value));
}