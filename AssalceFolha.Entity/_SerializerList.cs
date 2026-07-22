using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace AssalceFolha.Entity
{
    public class _XmlSerialization<T> where T : class
        {
            //XmlSerialize method 
            public string XmlSerialize(IList<T> list)
            {
                System.Xml.Serialization.XmlSerializer xmlSer = new System.Xml.Serialization.XmlSerializer(list.GetType());
                StringWriter textWriter = new StringWriter();
                xmlSer.Serialize(textWriter, list);
                xmlSer = null;
                return textWriter.ToString();
            }

            //XmlDeserialize method 
            public List<T> XmlDeserialize(String data)
            {
                System.Xml.Serialization.XmlSerializer xmlSer = new System.Xml.Serialization.XmlSerializer(typeof(List<T>));
                TextReader reader = new StringReader(data);
                object obj = xmlSer.Deserialize(reader);
                return (List<T>)obj;
            }

            //XmlSerialize method 
            public string XmlSerializeObjeto(T obj)
            {
                System.Xml.Serialization.XmlSerializer xmlSer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                StringWriter textWriter = new StringWriter();
                xmlSer.Serialize(textWriter, obj);
                xmlSer = null;
                return textWriter.ToString();
            }

            //XmlDeserialize method 
            public T XmlDeserializeObjeto(String data)
            {
                System.Xml.Serialization.XmlSerializer xmlSer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                TextReader reader = new StringReader(data);
                object obj = xmlSer.Deserialize(reader);
                return (T)obj;
            }
        }
	
	public class _SerializerList<T> where T: class
    {
	    _XmlSerialization<T> serializer = new _XmlSerialization<T>();

	    public List<T> GetListSerialize(string serialized_object)
	    {
            return (List<T>)new _XmlSerialization<T>().XmlDeserialize(serialized_object);
	    }

	    public List<T> GetListSerialize(object serialized_object)
	    {
		    if (serialized_object!=null)
		    {
			    return (List<T>)new _XmlSerialization<T>().XmlDeserialize(serialized_object.ToString());    
		    }
		    return new List<T>();
	    }

	    public string SerializeList(List<T> list)
	    {
		    if (list!=null)
		    {
			    return new _XmlSerialization<T>().XmlSerialize(list);
		    }

		    return null;
		
	    }
    }
}
