import { Component, inject } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LayoutService } from "../../../lib/services/layout.service";
import { SidebarComponent } from "../sidebar/sidebar.component";

@Component({
  selector: "app-mobile-drawer",
  standalone: true,
  imports: [CommonModule, SidebarComponent],
  templateUrl: "./mobile-drawer.html",
})
export class MobileDrawer {
  public layoutService = inject(LayoutService);

  protected closeMenu(): void {
    this.layoutService.closeMobileMenu();
  }
}