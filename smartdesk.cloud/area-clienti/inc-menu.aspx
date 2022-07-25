<ul class="menu vertical medium-horizontal" data-responsive-menu="drilldown medium-dropdown">
  <% if (boolEnableproducts){ %>
  <li><a href="/area-clienti/home.aspx#sectionanagraficheprodotti" title="Prodotti" data-smooth-scroll><i class="fa-duotone fa-cube fa-fw fa-lg"></i>Prodotti</a></li>
  <% } %>
  <% if (boolEnableprojects){ %>
  <li><a href="/area-clienti/home.aspx#sectionprogetti" title="Progetti" data-smooth-scroll><i class="fa-duotone fa-building fa-fw fa-lg"></i>Progetti e contratti ad ore</a></li>
  <% } %>
  <% if (boolEnableticket){ %>
  <li><a href="/area-clienti/home.aspx#sectionTicket" title="Ticket" data-smooth-scroll>Ticket</a></li>
  <% } %>
  <li><a href="/area-clienti/logout.aspx" title="Logout"><i class="fa-duotone fa-power-off fa-fw"></i>Esci</a></li>
</ul>
