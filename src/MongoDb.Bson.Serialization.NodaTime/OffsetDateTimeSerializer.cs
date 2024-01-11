using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class OffsetDateTimeSerializer : SerializerBase<OffsetDateTime>
{
    public override OffsetDateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) => 
        OffsetDateTimePattern.FullRoundtrip.Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, OffsetDateTime value) => 
        context.Writer.WriteString(OffsetDateTimePattern.FullRoundtrip.Format(value));
}