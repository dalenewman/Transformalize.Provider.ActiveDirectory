### Overview

The start of an Active Directory input provider for Transformalize.

### Usage

```xml
<cfg name="readme">

   <connections>
      <!-- note the delimiter is used for split multi-value attributes (e.g. memberOf) -->
      <add name="input" provider="activedirectory" delimiter="|" />
   </connections>

   <entities>
      <add name="entity" page="1" size="10">
         <filter>
            <!-- https://docs.microsoft.com/en-us/windows/desktop/adsi/search-filter-syntax -->
            <add expression="(&(mail=*)(objectClass=user)(objectCategory=person))" />
         </filter>
         <fields>
            <add name="cn" alias="Name" />
            <add name="mail" alias="Mail" primary-key="true" length="128" />
            <add name="telephoneNumber" alias="Phone" />
            <add name="mobile" alias="Mobile" />
         </fields>
      </add>
   </entities>
</cfg>
```

Active Directory requires you know what attributes are 
available and a [special syntax](https://docs.microsoft.com/en-us/windows/desktop/adsi/search-filter-syntax) for filtering them.