import { OidcStandardClaims } from "oidc-client-ts";

export interface User extends OidcStandardClaims {
  vendorcode?: string | null;
  company?: string | null;
  roles?: string[];
}
