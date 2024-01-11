using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class OffsetDateSerializer : SerializerBase<OffsetDate>
{
    public override OffsetDate Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) => 
        OffsetDatePattern.FullRoundtrip.Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, OffsetDate value) => 
        context.Writer.WriteString(OffsetDatePattern.FullRoundtrip.Format(value));
}