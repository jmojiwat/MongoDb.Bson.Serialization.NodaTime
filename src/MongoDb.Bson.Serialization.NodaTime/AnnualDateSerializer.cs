using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;

namespace MongoDb.Bson.Serialization.NodaTime;

public class AnnualDateSerializer : SerializerBase<AnnualDate>
{
    public override AnnualDate Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        context.Reader.ReadStartArray();
        var month = context.Reader.ReadInt32();
        var day = context.Reader.ReadInt32();
        context.Reader.ReadEndArray();

        return new AnnualDate(month, day);
    }

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, AnnualDate value)
    {
        context.Writer.WriteStartArray();
        context.Writer.WriteInt32(value.Month);
        context.Writer.WriteInt32(value.Day);
        context.Writer.WriteEndArray();
    }
}