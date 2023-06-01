namespace Finway.extantion
{
    public class GenericResponse<T>
    {
        public string ResponseTextArabic { get; set; }

        public string ResponseText { get; set; }

        public T ResponseObject { get; set; }

        public int ResponseCode { get; set; }

        public EnumStatus Status { get; set; }
    }
}
