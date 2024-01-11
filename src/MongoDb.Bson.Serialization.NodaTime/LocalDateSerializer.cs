using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class LocalDateSerializer : SerializerBase<LocalDate>
{
    public override LocalDate Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) =>
        LocalDatePattern.FullRoundtrip.Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, LocalDate value) =>
        context.Writer.WriteString(LocalDatePattern.FullRoundtrip.Format(value));
}