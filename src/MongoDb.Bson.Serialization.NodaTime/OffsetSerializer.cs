using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class OffsetSerializer : SerializerBase<Offset>
{
    public override Offset Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) => 
        OffsetPattern.GeneralInvariant.Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Offset value) => 
        context.Writer.WriteString(OffsetPattern.GeneralInvariant.Format(value));
}