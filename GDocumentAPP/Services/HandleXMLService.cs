using DropZoneFileUpload.Models;
using GDocumentAPP.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;

namespace GDocumentAPP.Services
{
    public class HandleXMLService
    {
      
        public List<TarifarioXML> getAllTarifarioXML(string pathTarifarioXml) {

            XmlTextReader reader = new XmlTextReader(pathTarifarioXml);
            List<TarifarioXML> tarifarioList = new List<TarifarioXML>();
            TarifarioXML tarifarioXml = new TarifarioXML();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == StructTarifario.nodeChild)
                    {
                        tarifarioXml = getTarifarioForReader(reader);
                      if (tarifarioXml.attributeTipo == StructTarifario.tipoFile) { 
                            string parentPath = ConfigurationManager.AppSettings["pathTarifarioImage"].ToString(); // @"\\sergenex02\Tarifario_Test\imagesTestDesarrollo";
                            string directoryImageConfig = ConfigurationManager.AppSettings["directoryImage"].ToString();
                            string pathServerImage = ConfigurationManager.AppSettings["pathServerImage"].ToString();

                            tarifarioXml.pathImage = System.IO.Path.Combine(parentPath, tarifarioXml.fileName);

                            var currentDirectory = System.AppDomain.CurrentDomain.BaseDirectory; 

                            var directoryImage = new DirectoryInfo(string.Format("{0}"+directoryImageConfig, currentDirectory.ToString()/*HttpContext.Current.Server.MapPath(@"\")*/));
                                                      
                            string destFileServer = System.IO.Path.Combine(directoryImage.ToString(), tarifarioXml.fileName);

                            System.IO.File.Copy(tarifarioXml.pathImage, destFileServer, true);

                            tarifarioXml.pathImage = System.IO.Path.Combine(pathServerImage, tarifarioXml.fileName);
                            tarifarioList.Add(tarifarioXml);
                        }
                  }
                }
            }
                reader.Close();
             return tarifarioList;
        }

        private static TarifarioXML getTarifarioForReader(XmlTextReader reader)
        {
            TarifarioXML tarifarioXml = new TarifarioXML();

            
                reader.MoveToAttribute(StructTarifario.tipo);
                tarifarioXml.attributeTipo = reader.Value;

                reader.MoveToAttribute(StructTarifario.rutaFileImage);
                tarifarioXml.attributeRuta = reader.Value;

                string rutaImagen = reader.Value;
                tarifarioXml.fileName = rutaImagen.Substring(rutaImagen.IndexOf('/')+1, rutaImagen.Length - rutaImagen.IndexOf('/')-1);

                reader.MoveToAttribute(StructTarifario.ordenFile);
                tarifarioXml.attributeOrden = int.Parse(reader.Value);

            return tarifarioXml;
        }

        public void WriteNewImageXml(TarifarioXML tarifarioXml){

               XmlDocument xmlDoc = new XmlDocument();
              
               xmlDoc.Load(tarifarioXml.pathTarifarioXml);
               XmlNode tarifariosNode = xmlDoc.SelectSingleNode(StructTarifario.nodeRoot);
                             
                XmlNode refChildNode = tarifariosNode.ChildNodes[tarifariosNode.ChildNodes.Count - 1];
                XmlNode newChildNode;
                newChildNode = xmlDoc.CreateNode(XmlNodeType.Element, StructTarifario.nodeChild, "");

                XmlAttribute attributeTipo = xmlDoc.CreateAttribute(StructTarifario.tipo);
                attributeTipo.Value = StructTarifario.tipoFile; 

                XmlAttribute attributeRuta = xmlDoc.CreateAttribute(StructTarifario.rutaFileImage);
                attributeRuta.Value = StructTarifario.rutaRelativaImage + tarifarioXml.fileName;  

                XmlAttribute attributeOrden = xmlDoc.CreateAttribute(StructTarifario.ordenFile);
                string refOrden = refChildNode.Attributes.GetNamedItem(StructTarifario.ordenFile).Value;
                int newOrden = int.Parse(refOrden) + 1;
                attributeOrden.Value = newOrden.ToString(); 

                tarifariosNode.InsertAfter(newChildNode, refChildNode);
                newChildNode.Attributes.Append(attributeTipo);
                newChildNode.Attributes.Append(attributeRuta);
                newChildNode.Attributes.Append(attributeOrden);
              
                xmlDoc.Save(tarifarioXml.pathTarifarioXml);
            }

        public bool isExistsImage(TarifarioXML paramTarifarioXml)
        {

            XmlTextReader reader = new XmlTextReader(paramTarifarioXml.pathTarifarioXml);
            List<TarifarioXML> tarifarioList = new List<TarifarioXML>();
            TarifarioXML tarifarioXml = new TarifarioXML();

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == StructTarifario.nodeChild)
                    {
                        tarifarioXml = getTarifarioForReader(reader);
                        if (tarifarioXml.attributeTipo == StructTarifario.tipoFile)
                        {
                            if (cleanExtension(tarifarioXml.fileName) == cleanExtension(paramTarifarioXml.fileName))
                            {
                                reader.Close();
                                return true;
                            }                                
                        }
                    }
                }
            }
            reader.Close();
            return false;
        }


        public void deleteNodeXml(TarifarioXML tarifarioXml) {
           
            XmlDocument tarifarioXmlConfig = new XmlDocument();
            
            tarifarioXmlConfig.Load(tarifarioXml.pathTarifarioXml);
          
            XmlNodeList nodesTarifario = tarifarioXmlConfig.SelectNodes(StructTarifario.nodes);
            for (int i = nodesTarifario.Count - 1; i >= 0; i--)
            {
                string pathImage = nodesTarifario[i].Attributes.GetNamedItem(StructTarifario.rutaFileImage).Value.ToString();
                string imageName = cleanExtension(Path.GetFileName(pathImage));
                string tarifarioImageName = cleanExtension(tarifarioXml.fileName);

                if  (imageName == tarifarioImageName)
                    nodesTarifario[i].ParentNode.RemoveChild(nodesTarifario[i]);
            }
           
            tarifarioXmlConfig.Save(tarifarioXml.pathTarifarioXml);
        }

        private static string cleanExtension(string stringForClean) {
           string stringClean = stringForClean.Substring(0, stringForClean.IndexOf('.'));
           return stringClean.ToLower();
        }

    }
}