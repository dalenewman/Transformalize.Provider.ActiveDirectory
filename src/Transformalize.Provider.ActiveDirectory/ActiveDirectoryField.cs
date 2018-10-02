namespace Transformalize.Provider.ActiveDirectory {
    public class ActiveDirectoryField {
        public string AttrLdapName { get; set; }
        public string AttrDisplayName { get; set; }
        public string AducTab { get; set; }
        public string AducField { get; set; }
        public string PropertySet { get; set; }
        public string StaticPropertyMethod { get; set; }
        public bool HiddenPerms { get; set; }
        public bool Mandatory { get; set; }
        public string Syntax { get; set; }
        public bool MultiValue { get; set; }
        public int MinRan { get; set; }
        public int MaxRan { get; set; }
        public string Oid { get; set; }
        public bool Gc { get; set; }
        public bool SystemOn { get; set; }
        public bool Indexed { get; set; }
        public bool Anr { get; set; }
        public bool Survives { get; set; }
        public bool Copied { get; set; }
        public bool NonRepl { get; set; }
        public bool Construct { get; set; }
    }
}
