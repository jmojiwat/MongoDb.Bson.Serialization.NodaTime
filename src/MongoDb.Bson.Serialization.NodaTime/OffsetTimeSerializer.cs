using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class OffsetTimeSerializer : SerializerBase<OffsetTime>
{
    public override OffsetTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) => 
        OffsetTimePattern.ExtendedIso.Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, OffsetTime value) => 
        context.Writer.WriteString(OffsetTimePattern.ExtendedIso.Format(value));
}