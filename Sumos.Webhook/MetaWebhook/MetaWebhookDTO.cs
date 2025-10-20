using System.Text.Json.Serialization;

namespace Sumos.Webhook.MetaWebhook;

public class WhatsAppWebhook
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = string.Empty;

    [JsonPropertyName("entry")]
    public List<Entry> Entry { get; set; } = [];
}

public class Entry
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("changes")]
    public List<Change> Changes { get; set; } = [];
}

public class Change
{
    [JsonPropertyName("field")]
    public string Field { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public WebhookValue Value { get; set; } = new();
}

public class WebhookValue
{
    [JsonPropertyName("messaging_product")]
    public string MessagingProduct { get; set; } = string.Empty;

    [JsonPropertyName("metadata")]
    public Metadata Metadata { get; set; } = new();

    [JsonPropertyName("contacts")]
    public List<Contact>? Contacts { get; set; }

    [JsonPropertyName("messages")]
    public List<Message>? Messages { get; set; }

    [JsonPropertyName("statuses")]
    public List<Status>? Statuses { get; set; }

    [JsonPropertyName("errors")]
    public List<Error>? Errors { get; set; }
}

public class Metadata
{
    [JsonPropertyName("display_phone_number")]
    public string DisplayPhoneNumber { get; set; } = string.Empty;

    [JsonPropertyName("phone_number_id")]
    public string PhoneNumberId { get; set; } = string.Empty;
}

public class Contact
{
    [JsonPropertyName("profile")]
    public Profile? Profile { get; set; }

    [JsonPropertyName("wa_id")]
    public string WaId { get; set; } = string.Empty;
}

public class Profile
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class Message
{
    [JsonPropertyName("from")]
    public string From { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("timestamp")]
    public string Timestamp { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("text")]
    public TextPayload? Text { get; set; }

    [JsonPropertyName("image")]
    public MediaPayload? Image { get; set; }

    [JsonPropertyName("video")]
    public VideoPayload? Video { get; set; }

    [JsonPropertyName("audio")]
    public AudioPayload? Audio { get; set; }

    [JsonPropertyName("document")]
    public DocumentPayload? Document { get; set; }

    [JsonPropertyName("sticker")]
    public StickerPayload? Sticker { get; set; }

    [JsonPropertyName("location")]
    public LocationPayload? Location { get; set; }

    [JsonPropertyName("contacts")]
    public List<SharedContact>? Contacts { get; set; }

    [JsonPropertyName("button")]
    public ButtonPayload? Button { get; set; }

    [JsonPropertyName("interactive")]
    public InteractivePayload? Interactive { get; set; }

    [JsonPropertyName("reaction")]
    public ReactionPayload? Reaction { get; set; }

    [JsonPropertyName("order")]
    public OrderPayload? Order { get; set; }

    [JsonPropertyName("system")]
    public SystemPayload? System { get; set; }

    [JsonPropertyName("context")]
    public ContextPayload? Context { get; set; }

    [JsonPropertyName("referral")]
    public ReferralPayload? Referral { get; set; }

    [JsonPropertyName("errors")]
    public List<Error>? Errors { get; set; }
}

public class TextPayload
{
    [JsonPropertyName("body")]
    public string Body { get; set; } = string.Empty;
}

public class MediaPayload
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("mime_type")]
    public string MimeType { get; set; } = string.Empty;

    [JsonPropertyName("sha256")]
    public string Sha256 { get; set; } = string.Empty;

    [JsonPropertyName("caption")]
    public string? Caption { get; set; }
}

public class VideoPayload : MediaPayload
{
}

public class AudioPayload : MediaPayload
{
}

public class DocumentPayload : MediaPayload
{
    [JsonPropertyName("filename")]
    public string? Filename { get; set; }
}

public class StickerPayload
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("mime_type")]
    public string MimeType { get; set; } = string.Empty;

    [JsonPropertyName("sha256")]
    public string Sha256 { get; set; } = string.Empty;

    [JsonPropertyName("animated")]
    public bool? Animated { get; set; }
}

public class LocationPayload
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }
}

public class SharedContact
{
    [JsonPropertyName("addresses")]
    public List<Address>? Addresses { get; set; }

    [JsonPropertyName("birthday")]
    public string? Birthday { get; set; }

    [JsonPropertyName("emails")]
    public List<Email>? Emails { get; set; }

    [JsonPropertyName("name")]
    public ContactName? Name { get; set; }

    [JsonPropertyName("org")]
    public Organization? Org { get; set; }

    [JsonPropertyName("phones")]
    public List<Phone>? Phones { get; set; }

    [JsonPropertyName("urls")]
    public List<Url>? Urls { get; set; }
}

public class Address
{
    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("street")]
    public string? Street { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("zip")]
    public string? Zip { get; set; }
}

public class Email
{
    [JsonPropertyName("email")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

public class ContactName
{
    [JsonPropertyName("formatted_name")]
    public string? FormattedName { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("middle_name")]
    public string? MiddleName { get; set; }

    [JsonPropertyName("suffix")]
    public string? Suffix { get; set; }

    [JsonPropertyName("prefix")]
    public string? Prefix { get; set; }
}

public class Organization
{
    [JsonPropertyName("company")]
    public string? Company { get; set; }

    [JsonPropertyName("department")]
    public string? Department { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}

public class Phone
{
    [JsonPropertyName("phone")]
    public string? Number { get; set; }

    [JsonPropertyName("wa_id")]
    public string? WaId { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

public class Url
{
    [JsonPropertyName("url")]
    public string? UrlAddress { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

public class ButtonPayload
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;

    [JsonPropertyName("payload")]
    public string? Payload { get; set; }
}

public class InteractivePayload
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("button_reply")]
    public ButtonReply? ButtonReply { get; set; }

    [JsonPropertyName("list_reply")]
    public ListReply? ListReply { get; set; }
}

public class ButtonReply
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;
}

public class ListReply
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

public class ReactionPayload
{
    [JsonPropertyName("message_id")]
    public string MessageId { get; set; } = string.Empty;

    [JsonPropertyName("emoji")]
    public string Emoji { get; set; } = string.Empty;
}

public class OrderPayload
{
    [JsonPropertyName("catalog_id")]
    public string CatalogId { get; set; } = string.Empty;

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("product_items")]
    public List<ProductItem>? ProductItems { get; set; }
}

public class ProductItem
{
    [JsonPropertyName("product_retailer_id")]
    public string ProductRetailerId { get; set; } = string.Empty;

    [JsonPropertyName("quantity")]
    public string Quantity { get; set; } = string.Empty;

    [JsonPropertyName("item_price")]
    public string ItemPrice { get; set; } = string.Empty;

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;
}

public class SystemPayload
{
    [JsonPropertyName("body")]
    public string Body { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("new_wa_id")]
    public string? NewWaId { get; set; }

    [JsonPropertyName("identity")]
    public string? Identity { get; set; }

    [JsonPropertyName("customer")]
    public string? Customer { get; set; }

    [JsonPropertyName("group_id")]
    public string? GroupId { get; set; }
}

public class ContextPayload
{
    [JsonPropertyName("from")]
    public string From { get; set; } = string.Empty;

    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("forwarded")]
    public bool? Forwarded { get; set; }

    [JsonPropertyName("frequently_forwarded")]
    public bool? FrequentlyForwarded { get; set; }

    [JsonPropertyName("referred_product")]
    public ReferredProduct? ReferredProduct { get; set; }
}

public class ReferredProduct
{
    [JsonPropertyName("catalog_id")]
    public string CatalogId { get; set; } = string.Empty;

    [JsonPropertyName("product_retailer_id")]
    public string ProductRetailerId { get; set; } = string.Empty;
}

public class ReferralPayload
{
    [JsonPropertyName("source_url")]
    public string? SourceUrl { get; set; }

    [JsonPropertyName("source_type")]
    public string? SourceType { get; set; }

    [JsonPropertyName("source_id")]
    public string? SourceId { get; set; }

    [JsonPropertyName("headline")]
    public string? Headline { get; set; }

    [JsonPropertyName("body")]
    public string? Body { get; set; }

    [JsonPropertyName("media_type")]
    public string? MediaType { get; set; }

    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    [JsonPropertyName("video_url")]
    public string? VideoUrl { get; set; }

    [JsonPropertyName("thumbnail_url")]
    public string? ThumbnailUrl { get; set; }

    [JsonPropertyName("ctwa_clid")]
    public string? CtwaClid { get; set; }
}

public class Error
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("details")]
    public string? Details { get; set; }

    [JsonPropertyName("href")]
    public string? Href { get; set; }

    [JsonPropertyName("error_data")]
    public ErrorData? ErrorData { get; set; }
}

public class ErrorData
{
    [JsonPropertyName("details")]
    public string Details { get; set; } = string.Empty;
}

public class Status
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string StatusKind { get; set; } = string.Empty;

    [JsonPropertyName("timestamp")]
    public string Timestamp { get; set; } = string.Empty;

    [JsonPropertyName("recipient_id")]
    public string RecipientId { get; set; } = string.Empty;

    [JsonPropertyName("conversation")]
    public Conversation? Conversation { get; set; }

    [JsonPropertyName("pricing")]
    public Pricing? Pricing { get; set; }

    [JsonPropertyName("errors")]
    public List<Error>? Errors { get; set; }
}

public class Conversation
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("expiration_timestamp")]
    public string? ExpirationTimestamp { get; set; }

    [JsonPropertyName("origin")]
    public Origin? Origin { get; set; }
}

public class Origin
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
}

public class Pricing
{
    [JsonPropertyName("billable")]
    public bool Billable { get; set; }

    [JsonPropertyName("pricing_model")]
    public string PricingModel { get; set; } = string.Empty;

    [JsonPropertyName("category")]
    public string Category { get; set; } = string.Empty;
}