using System.Xml;

namespace IOFxml
{
    public class IOFReader
    {
        Product product;
        System.Xml.XmlTextReader reader;

        public Product Product { get => product; set => product = value; }

        public void OpenFile(string file)
        {
            reader = new XmlTextReader(file);
        }

        public bool ReadNextProduct()
        {
            if (reader.ReadToFollowing("product"))
            {
                product = new Product();
                GetProduct();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GetProduct()
        {
            string product = XmlString.FocusXml("product", reader.ReadOuterXml());

            GetProductInfo(product);
            GetProducer(product);
            GetCategory(product);
            GetCard(product);
            GetDescription(product);
            GetIaiextSizes(product);
            GetImages(product);
        }

        void GetProductInfo(string content)
        {
            product.Id = XmlString.GetNodeAttribute("id", "product", content);
            product.CodeProducer = XmlString.GetNodeAttribute("code_producer", "product", content);
            product.IaiextVat = XmlString.GetNodeAttribute("vat", "product", content);
        }

        void GetProducer(string content)
        {
            product.Producer.Id = XmlString.GetNodeAttribute("id", "producer", content);
            product.Producer.Name = XmlString.GetNodeAttribute("name", "product", content);
        }

        void GetCategory(string content)
        {
            product.Category.Id = XmlString.GetNodeAttribute("id", "category", content);
            product.Category.XmlLang = XmlString.GetNodeAttribute("lang", "category", content);
            product.Category.Name = XmlString.GetNodeAttribute("name", "category", content);
        }

        public void GetCard(string content)
        {
            product.Card.Url = XmlString.GetNodeAttribute("url", "card", content);
        }

        public void GetDescription(string content)
        {
            string description = XmlString.FocusXml("description", content);

            GetNames(description);
            GetLongDescs(description);
            GetShortDescs(description);
        }

        void GetNames(string content)
        {
            using (XmlReader r = XmlString.CreateReader(content))
            {
                while (r.ReadToFollowing("name"))
                {
                    string name = XmlString.FocusXml("name", r.ReadOuterXml());
                    GetName(name);
                }
            }
        }

        void GetName(string content)
        {
            Name name = new Name();

            name.Xml_lang = XmlString.GetNodeAttribute("lang", "name", content);
            name.Value = XmlString.GetNodeContent("name", content);

            product.Description.Name.Add(name);
        }

        void GetLongDescs(string content)
        {
            using (XmlReader r = XmlString.CreateReader(content))
            {
                while (r.ReadToFollowing("long_desc"))
                {
                    string long_desc = XmlString.FocusXml("long_desc", r.ReadOuterXml());
                    GetLongDesc(long_desc);
                }
            }
        }

        void GetLongDesc(string content)
        {
            LongDesc long_desc = new LongDesc();

            long_desc.Xml_lang = XmlString.GetNodeAttribute("lang", "long_desc", content);
            long_desc.Value = XmlString.GetNodeContent("long_desc", content);

            product.Description.LongDesc.Add(long_desc);
        }

        void GetShortDescs(string content)
        {
            using (XmlReader r = XmlString.CreateReader(content))
            {
                while (r.ReadToFollowing("short_desc"))
                {
                    string short_desc = XmlString.FocusXml("short_desc", r.ReadOuterXml());
                    GetShortDesc(short_desc);
                }
            }
        }

        void GetShortDesc(string content)
        {
            ShortDesc short_desc = new ShortDesc();

            short_desc.Xml_lang = XmlString.GetNodeAttribute("lang", "short_desc", content);
            short_desc.Value = XmlString.GetNodeContent("short_desc", content);

            product.Description.ShortDesc.Add(short_desc);
        }

        void GetIaiextSizes(string content)
        {
            string iaiext_sizes = XmlString.FocusXml("sizes", content);

            using (XmlReader r = XmlString.CreateReader(iaiext_sizes))
            {
                while (r.ReadToFollowing("size"))
                {
                    string iaiext_size = XmlString.FocusXml("size", r.ReadOuterXml());
                    GetIaiextSize(iaiext_size);
                }
            }
        }

        void GetIaiextSize(string content)
        {
            IaiextSize iaiext_size = new IaiextSize();

            iaiext_size.Id = XmlString.GetNodeAttribute("id", "size", content);
            iaiext_size.SizeName = XmlString.GetNodeAttribute("size_name", "size", content);
            iaiext_size.SizePanelName = XmlString.GetNodeAttribute("size_panel_name", "size", content);
            iaiext_size.Code = XmlString.GetNodeAttribute("code", "size", content);
            iaiext_size.Weight = XmlString.GetNodeAttribute("weight", "size", content);
            iaiext_size.CodeProducer = XmlString.GetNodeAttribute("code_producer", "size", content);
            iaiext_size.CodeExternal = XmlString.GetNodeAttribute("code_external", "size", content);
            iaiext_size.Available = XmlString.GetNodeAttribute("available", "size", content);

            product.IaiextSizes.IaiextSize.Add(iaiext_size);
        }

        void GetImages(string content)
        {
            string images = XmlString.FocusXml("images", content);

            GetLarge(images);
            GetIcons(images);
        }

        void GetLarge(string content)
        {
            string large = XmlString.FocusXml("large", content);

            using (XmlReader r = XmlString.CreateReader(large))
            {
                while (r.ReadToFollowing("image"))
                {
                    string image = XmlString.FocusXml("image", r.ReadOuterXml());
                    GetImage(image);
                }
            }
        }

        void GetImage(string content)
        {
            Image image = new Image();

            image.Url = XmlString.GetNodeAttribute("url", "image", content);
            image.DateChanged = XmlString.GetNodeAttribute("date_changed", "image", content);
            image.Hash = XmlString.GetNodeAttribute("hash", "image", content);
            image.IaiextHeight = XmlString.GetNodeAttribute("height", "image", content);
            image.IaiextWidth = XmlString.GetNodeAttribute("width", "image", content);

            product.Images.Large.Image.Add(image);
        }

        void GetIcons(string content)
        {
            string icons = XmlString.FocusXml("icons", content);

            using (XmlReader r = XmlString.CreateReader(icons))
            {
                while (r.ReadToFollowing("icone"))
                {
                    string icone = XmlString.FocusXml("icone", r.ReadOuterXml());
                    GetIcone(icone);
                }
            }
        }

        void GetIcone(string content)
        {
            Icon icon = new Icon();

            icon.Url = XmlString.GetNodeAttribute("url", "icon", content);
            icon.DateChanged = XmlString.GetNodeAttribute("date_changed", "icon", content);
            icon.Hash = XmlString.GetNodeAttribute("hash", "icon", content);
            icon.IaiextHeight = XmlString.GetNodeAttribute("height", "icon", content);
            icon.IaiextWidth = XmlString.GetNodeAttribute("width", "icon", content);

            product.Images.Icons.Icon.Add(icon);
        }

        public void CloseReader()
        {
            reader.Close();
        }
    }
}
