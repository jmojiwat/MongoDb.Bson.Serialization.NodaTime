using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class PeriodSerializer : SerializerBase<Period>
{
    public override Period Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) => 
        PeriodPattern.Roundtrip.Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, Period value) => 
        context.Writer.WriteString(PeriodPattern.Roundtrip.Format(value));
}