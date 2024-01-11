using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class LocalDateTimeSerializer : SerializerBase<LocalDateTime>
{
    public override LocalDateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) =>
        LocalDateTimePattern.FullRoundtrip.Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, LocalDateTime value) =>
        context.Writer.WriteString(LocalDateTimePattern.FullRoundtrip.Format(value));
}