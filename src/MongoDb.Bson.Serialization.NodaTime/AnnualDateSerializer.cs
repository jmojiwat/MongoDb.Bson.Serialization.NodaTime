using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using NodaTime;
using NodaTime.Text;

namespace MongoDb.Bson.Serialization.NodaTime;

public class AnnualDateSerializer : SerializerBase<AnnualDate>
{
    public override AnnualDate Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args) => 
        AnnualDatePattern.Iso.Parse(context.Reader.ReadString()).Value;

    public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, AnnualDate value) => 
        context.Writer.WriteString(AnnualDatePattern.Iso.Format(value));
}