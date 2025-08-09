<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsque votre personnage n’explore pas des terres sauvages, un réseau de cavernes ou un vaste océan, il peut adopter un style de vie afin de couvrir ses
      besoins de logis et de nourriture.
    </p>
    <p>
      Bien que cela ne soit pas gratuit, il peut certainement mieux apprécier le confort de son style de vie s’il peut simplement débourser une somme en
      déléguant cette responsabilité à d’autres.
    </p>
    <p>
      Les différents styles de vie sont décrits ci-dessous. Les prix indiqués sont en deniers par jour, et incluent le logement, la nourriture et toute dépense
      encourue par le personnage, par exemple la maintenance de son équipement afin qu’il soit prêt à retourner à l’aventure.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-10">Style de vie</th>
          <th scope="col" class="w-10">Prix</th>
          <th scope="col" class="w-80">Description</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Misérable</td>
          <td>—</td>
          <td>
            Le personnage vit dans des conditions inhumaines, sans lieu de résidence. Il se réfugie là où il le peut et compte sur les bonnes grâces et la pitié
            de la populace locale afin de survivre. Il attire la jalousie d’autres misérables comme lui et inspire la pitié aux classes sociales plus aisées.
          </td>
        </tr>
        <tr>
          <td>Sordide</td>
          <td>0,1</td>
          <td>
            Le personnage a un refuge, un endroit qu’il peut considérer comme son domicile, une protection contre les intempéries. Celui-ci peut être fragile ou
            infesté de vermine, mais il en demeure un domicile. Le personnage inspire plus de dégoût que de pitié, et ne bénéficie que de peu de protection
            légale.
          </td>
        </tr>
        <tr>
          <td>Pauvre</td>
          <td>0,2</td>
          <td>
            Moins confortable que la moyenne, le personnage doit faire sans les luxes d’une communauté stable et établie. Néanmoins, ses besoins primaires sont
            comblés, et il bénéficie d’une certaine protection légale. Il peut également compter sur les membres de sa communauté et attire la jalousie des
            moins fortunés.
          </td>
        </tr>
        <tr>
          <td>Modeste</td>
          <td>1</td>
          <td>
            Ce style de vie permet au personnage d’éviter les taudis et de maintenir son équipement. Ses besoins primaires sont comblés et il bénéfice de
            quelques conforts, ainsi que d’une bonne protection légale. En ne fréquentant pas les lieux non recommandés, il s’évite ainsi les risques et dangers
            associés.
          </td>
        </tr>
        <tr>
          <td>Confortable</td>
          <td>2</td>
          <td>
            Le personnage peut s’offrir un certain luxe dépassant le simple confort, par exemple des vêtements plus agréables à porter ou une meilleure
            maintenance de son équipement. Il contribue à une communauté qui le respecte et exploite son potentiel.
          </td>
        </tr>
        <tr>
          <td>Fortuné</td>
          <td>4</td>
          <td>
            Le personnage bénéficie de nombreux luxes, par exemple une maison spacieuse ou installée dans un quartier plus riche. Il peut se permettre des repas
            gastronomiques et des suites somptueuses lors de ses voyages, et n’hésite aucunement à dépenser afin de se divertir.
          </td>
        </tr>
        <tr>
          <td>Aristocratique</td>
          <td>10 et plus</td>
          <td>
            Le personnage peut faire partie de la noblesse ou des hautes sphères de sa société. Il est reconnu et admiré par les classes sociales moins riches.
            Il possède la plus grosse demeure de son quartier ou l’une des plus huppées. Il reçoit des invitations à des événements de toute sorte parmi son
            réseau de contacts aisés.
          </td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Dépenses";

useSeo({
  title,
  description: "Découvrez les différents styles de vie, leurs coûts et avantages, pour loger et nourrir votre personnage en dehors de ses aventures.",
});
</script>
La table ci-dessous indique le prix d’un style de vie par jour. Ce prix inclut le logement, la nourriture et
