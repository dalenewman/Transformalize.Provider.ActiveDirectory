### Overview

This is the beginnings of an Active Directory input provider for Transformalize. It is a plug-in compatible with Transformalize 0.3.8-beta.

Build the Autofac project and put it's output into Transformalize's *plugins* folder.

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

**Caution**: Active Directory requires you know what attributes are available and a special syntax for filtering them.