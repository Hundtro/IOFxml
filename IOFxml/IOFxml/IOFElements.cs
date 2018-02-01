using System.Collections.Generic;

namespace IOFxml
{
    public class Product
    {
        string id;
        string code_producer;
        string iaiext_vat;

        Producer producer;
        Category category;
        Card card;
        Description description;
        IaiextSizes iaiext_sizes;
        Images images;

        public Product()
        {
            producer = new Producer();
            category = new Category();
            card = new Card();
            description = new Description();
            iaiext_sizes = new IaiextSizes();
            images = new Images();
        }

        public string Id { get => id; set => id = value; }
        public string CodeProducer { get => code_producer; set => code_producer = value; }
        public string IaiextVat { get => iaiext_vat; set => iaiext_vat = value; }
        public Producer Producer { get => producer; set => producer = value; }
        public Category Category { get => category; set => category = value; }
        public Card Card { get => card; set => card = value; }
        public Description Description { get => description; set => description = value; }
        public IaiextSizes IaiextSizes { get => iaiext_sizes; set => iaiext_sizes = value; }
        public Images Images { get => images; set => images = value; }

    }

    public class Producer
    {
        string id;
        string name;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }

    public class Category
    {
        string id;
        string xml_lang;
        string name;

        public string Id { get => id; set => id = value; }
        public string XmlLang { get => xml_lang; set => xml_lang = value; }
        public string Name { get => name; set => name = value; }
    }

    public class Card
    {
        string url;

        public string Url { get => url; set => url = value; }
    }

    public class Description
    {
        List<Name> name;
        List<LongDesc> long_desc;
        List<ShortDesc> short_desc;

        public Description()
        {
            name = new List<Name>();
            long_desc = new List<LongDesc>();
            short_desc = new List<ShortDesc>();
        }

        public List<Name> Name { get => name; set => name = value; }
        public List<LongDesc> LongDesc { get => long_desc; set => long_desc = value; }
        public List<ShortDesc> ShortDesc { get => short_desc; set => short_desc = value; }
    }

    public class Name
    {
        string xml_lang;
        string value;

        public string Xml_lang { get => xml_lang; set => xml_lang = value; }
        public string Value { get => value; set => this.value = value; }
    }

    public class LongDesc
    {
        string xml_lang;
        string value;

        public string Xml_lang { get => xml_lang; set => xml_lang = value; }
        public string Value { get => value; set => this.value = value; }
    }

    public class ShortDesc
    {
        string xml_lang;
        string value;

        public string Xml_lang { get => xml_lang; set => xml_lang = value; }
        public string Value { get => value; set => this.value = value; }
    }

    public class IaiextSizes
    {
        List<IaiextSize> iaiext_size;

        public IaiextSizes()
        {
            iaiext_size = new List<IaiextSize>();
        }

        public List<IaiextSize> IaiextSize { get => iaiext_size; set => iaiext_size = value; }
    }

    public class IaiextSize
    {
        string id;
        string size_name;
        string size_panel_name;
        string code;
        string weight;
        string code_producer;
        string code_external;
        string available;

        public string Id { get => id; set => id = value; }
        public string SizeName { get => size_name; set => size_name = value; }
        public string SizePanelName { get => size_panel_name; set => size_panel_name = value; }
        public string Code { get => code; set => code = value; }
        public string Weight { get => weight; set => weight = value; }
        public string CodeProducer { get => code_producer; set => code_producer = value; }
        public string CodeExternal { get => code_external; set => code_external = value; }
        public string Available { get => available; set => available = value; }
    }

    public class Images
    {
        Large large;
        Icons icons;

        public Images()
        {
            large = new Large();
            icons = new Icons();
        }

        public Large Large { get => large; set => large = value; }
        public Icons Icons { get => icons; set => icons = value; }
    }

    public class Large
    {
        List<Image> image;

        public Large()
        {
            image = new List<Image>();
        }

        public List<Image> Image { get => image; set => image = value; }
    }

    public class Icons
    {
        List<Icon> icon;

        public Icons()
        {
            icon = new List<Icon>();
        }

        public List<Icon> Icon { get => icon; set => icon = value; }
    }

    public class Image
    {
        string url;
        string date_changed;
        string hash;
        string iaiext_height;
        string iaiext_width;

        public string Url { get => url; set => url = value; }
        public string DateChanged { get => date_changed; set => date_changed = value; }
        public string Hash { get => hash; set => hash = value; }
        public string IaiextHeight { get => iaiext_height; set => iaiext_height = value; }
        public string IaiextWidth { get => iaiext_width; set => iaiext_width = value; }
    }

    public class Icon
    {
        string url;
        string date_changed;
        string hash;
        string iaiext_height;
        string iaiext_width;

        public string Url { get => url; set => url = value; }
        public string DateChanged { get => date_changed; set => date_changed = value; }
        public string Hash { get => hash; set => hash = value; }
        public string IaiextHeight { get => iaiext_height; set => iaiext_height = value; }
        public string IaiextWidth { get => iaiext_width; set => iaiext_width = value; }
    }
}
