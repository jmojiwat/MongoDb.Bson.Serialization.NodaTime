using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class LocalTimeSerializer : SerializerBase<LocalTime>
{
    public override LocalTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) => 
        LocalTimePattern.LongExtendedIso.Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, LocalTime value) => 
        context.Writer.WriteString(LocalTimePattern.LongExtendedIso.Format(value));
}