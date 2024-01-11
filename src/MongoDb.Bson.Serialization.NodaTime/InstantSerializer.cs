using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class InstantSerializer : SerializerBase<Instant>
{
    public override Instant Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) => 
        InstantPattern.General.Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Instant value) => 
        context.Writer.WriteString(InstantPattern.General.Format(value));
}