using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace PracaXaf.Module.Help
{
    [XmlRoot(ElementName = "root")]
    public class DaneRaportPrawna
    {

        private DaneRaportPrawnaDane daneField;

        private static XmlSerializer serializer;

        [XmlElement(ElementName = "dane")]
        public DaneRaportPrawnaDane dane { get; set; }


        public DaneRaportPrawna()
        {
            daneField = new DaneRaportPrawnaDane();
        }

        private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializer(typeof(DaneRaportPrawna));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current root object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                streamReader?.Dispose();
                memoryStream?.Dispose();
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an root object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output root object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out DaneRaportPrawna obj, out Exception exception)
        {
            exception = null;
            obj = default(DaneRaportPrawna);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out DaneRaportPrawna obj)
        {
            return Deserialize(xml, out obj, out Exception exception);
        }

        public static DaneRaportPrawna Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((DaneRaportPrawna)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                stringReader?.Dispose();
            }
        }


      
        }


      
        #endregion
    }

    [XmlRoot(ElementName = "dane")]
    public class DaneRaportPrawnaDane
    {
        private static XmlSerializer serializer;

        public string Nazwa { get; set; }
    public string Regon { get; set; }
    public string Miejscowosc { get; set; }



    private static XmlSerializer Serializer
        {
            get
            {
                if ((serializer == null))
                {
                    serializer = new XmlSerializer(typeof(DaneRaportPrawnaDane));
                }
                return serializer;
            }
        }

        #region Serialize/Deserialize
        /// <summary>
        /// Serializes current rootDane object into an XML document
        /// </summary>
        /// <returns>string XML value</returns>
        public virtual string Serialize()
        {
            StreamReader streamReader = null;
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream();
                Serializer.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                streamReader = new StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                streamReader?.Dispose();
                memoryStream?.Dispose();
            }
        }

        /// <summary>
        /// Deserializes workflow markup into an rootDane object
        /// </summary>
        /// <param name="xml">string workflow markup to deserialize</param>
        /// <param name="obj">Output rootDane object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool Deserialize(string xml, out DaneRaportPrawnaDane obj, out Exception exception)
        {
            exception = null;
            obj = default(DaneRaportPrawnaDane);
            try
            {
                obj = Deserialize(xml);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool Deserialize(string xml, out DaneRaportPrawnaDane obj)
        {
            return Deserialize(xml, out obj, out Exception exception);
        }

        public static DaneRaportPrawnaDane Deserialize(string xml)
        {
            StringReader stringReader = null;
            try
            {
                stringReader = new StringReader(xml);
                return ((DaneRaportPrawnaDane)(Serializer.Deserialize(XmlReader.Create(stringReader))));
            }
            finally
            {
                stringReader?.Dispose();
            }
        }

        /// <summary>
        /// Serializes current rootDane object into file
        /// </summary>
        /// <param name="fileName">full path of outupt xml file</param>
        /// <param name="exception">output Exception value if failed</param>
        /// <returns>true if can serialize and save into file; otherwise, false</returns>
        public virtual bool SaveToFile(string fileName, out Exception exception)
        {
            exception = null;
            try
            {
                SaveToFile(fileName);
                return true;
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }

        public virtual void SaveToFile(string fileName)
        {
            StreamWriter streamWriter = null;
            try
            {
                string xmlString = Serialize();
                FileInfo xmlFile = new FileInfo(fileName);
                streamWriter = xmlFile.CreateText();
                streamWriter.WriteLine(xmlString);
                streamWriter.Close();
            }
            finally
            {
                streamWriter?.Dispose();
            }
        }

        /// <summary>
        /// Deserializes xml markup from file into an rootDane object
        /// </summary>
        /// <param name="fileName">string xml file to load and deserialize</param>
        /// <param name="obj">Output rootDane object</param>
        /// <param name="exception">output Exception value if deserialize failed</param>
        /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
        public static bool LoadFromFile(string fileName, out DaneRaportPrawnaDane obj, out Exception exception)
        {
            exception = null;
            obj = default(DaneRaportPrawnaDane);
            try
            {
                obj = LoadFromFile(fileName);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }

        public static bool LoadFromFile(string fileName, out DaneRaportPrawnaDane obj)
        {
            return LoadFromFile(fileName, out obj, out Exception exception);
        }

        public static DaneRaportPrawnaDane LoadFromFile(string fileName)
        {
            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(file);
                string xmlString = sr.ReadToEnd();
                sr.Close();
                file.Close();
                return Deserialize(xmlString);
            }
            finally
            {
                file?.Dispose();
                sr?.Dispose();
            }
        }
        #endregion
    }



