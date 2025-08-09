<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      La fortune des aventuriers s’exprime de diverses manières : monnaie ou argent, pierres précieuses, œuvres d’art, ressources, immobiliers, etc. La forme la
      plus courante de richesse est la monnaie.
    </p>
    <h2 class="h3">Différents systèmes</h2>
    <p>
      Il existe plusieurs systèmes de monnaie utilisés par différentes entités géopolitiques, et on ne peut généralement pas utiliser une monnaie étrangère
      comme moyen de paiement.
    </p>
    <p>Certaines institutions, comme les banques, maintiennent des tables de conversion permettant d’échanger de la monnaie d’un système à un autre.</p>
    <p>Certains marchands possèdent également des tables similaires, ce qui leur permet d’accepter de la monnaie de plusieurs systèmes différents.</p>
    <h2 class="h3">Le denier d’argent d’Ouespéro</h2>
    <p>
      En Ouespéro, le système le plus couramment utilisé est celui du <strong>denier d’argent</strong>. Ce système fut mis en place graduellement par les
      empereurs et grands rois de la région afin de remplacer la monnaie d’or alors utilisée. Ce changement est explicable par la rareté de l’or ainsi que la
      découverte d’une abondance de mines d’argent dans la région.
    </p>
    <p>
      D’un pays à un autre, les figures et motifs frappés sur la pièce peuvent différer, par exemple le visage du dirigeant, les emblèmes du pays ou même un
      symbole naturel tel une plante ou un animal. En revanche, toutes ces pièces ont la même valeur, puisque cette valeur est basée sur le poids de ces pièces.
    </p>
    <p>Chacune de ces pièces pèse environ 5 grammes : 200 pièces pèsent donc 1 kilogramme.</p>
    <h3 class="h5">Composition</h3>
    <p>Ce système est composé des pièces suivantes :</p>
    <ul>
      <li>
        <strong>Centime.</strong> Une pièce de cuivre utilisée principalement les membres les plus pauvres de la société pour les achats courants telle la
        nourriture. Cette pièce est aussi appelée «&nbsp;sou&nbsp;» et «&nbsp;liard&nbsp;».
      </li>
      <li>
        <strong>Dîme.</strong> Une pièce de billon (alliage de cuivre, de zinc et d’argent) couramment utilisée par la plupart des membres de la société pour
        leurs achats de faible valeur, tels des vêtements et outils.
      </li>
      <li>
        <strong>Denier.</strong> Une pièce d’argent couramment utilisée par la plupart des membres de la société pour leurs achats de plus grande valeur, comme
        le bétail de moyens de transport. Il s’agit de l’unité de référence de ce système.
      </li>
      <li>
        <strong>Écu.</strong> Une pièce d’électrum (alliage d’argent et d’or) utilisée par les nobles, bourgeois et riches marchands pour payer certains achats
        en moins de pièces de monnaie.
      </li>
      <li>
        <strong>Couronne.</strong> Une pièce d’or réservée aux membres les plus riches de la société. Vu la rareté de l’or, cette pièce est plus rarement
        utilisée que l’écu, et son usage est surveillé. Par exemple, si un paysan est surpris à payer avec des couronnes, il sera suspecté de les avoir dérobées
        à un noble, et elles lui seront généralement confisquées.
      </li>
      <li>
        <strong>Galion.</strong> Une pièce de platine qui ne fait pas partie du système du denier d’argent. De ce fait, il ne sera jamais accepté par les
        marchands. Néanmoins, il est reconnu par certaines grandes institutions puisqu’il a déjà été utilisé par d’anciens empires possédant la magie ou la
        technologie d’extraire et de transformer ce rare métal. Cette pièce est extrêmement rare et on n’en retrouvera généralement que dans les ruines de ces
        anciens empires. Le fait d’échanger ou même de posséder ces pièces éveillera toujours les soupçons.
      </li>
    </ul>
    <h3 class="h5">Comparaison</h3>
    <p>
      La table suivante montre la valeur des pièces relativement aux autres pièces de monnaie de ce système. Par exemple, un écu vaut 10 deniers, et 1 000
      centimes valent un écu.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col">Pièce</th>
          <th scope="col">Centime</th>
          <th scope="col">Dîme</th>
          <th scope="col">Denier</th>
          <th scope="col">Écu</th>
          <th scope="col">Couronne</th>
          <th scope="col">Galion</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <th scope="row">Centime</th>
          <td>1</td>
          <td>1/10</td>
          <td>1/100</td>
          <td>1/1000</td>
          <td>1/10000</td>
          <td>1/100000</td>
        </tr>
        <tr>
          <th scope="row">Dîme</th>
          <td>10</td>
          <td>1</td>
          <td>1/10</td>
          <td>1/100</td>
          <td>1/1000</td>
          <td>1/10000</td>
        </tr>
        <tr>
          <th scope="row">Denier</th>
          <td>100</td>
          <td>10</td>
          <td>1</td>
          <td>1/10</td>
          <td>1/100</td>
          <td>1/1000</td>
        </tr>
        <tr>
          <th scope="row">Écu</th>
          <td>1000</td>
          <td>100</td>
          <td>10</td>
          <td>1</td>
          <td>1/10</td>
          <td>1/100</td>
        </tr>
        <tr>
          <th scope="row">Couronne</th>
          <td>10000</td>
          <td>1000</td>
          <td>100</td>
          <td>10</td>
          <td>1</td>
          <td>1/10</td>
        </tr>
        <tr>
          <th scope="row">Galion</th>
          <td>100000</td>
          <td>10000</td>
          <td>1000</td>
          <td>100</td>
          <td>10</td>
          <td>1</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Système de monnaie";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [];

useSeo({
  title,
  description:
    "Découvrez les systèmes monétaires et les pièces d’Ouespéro, du centime au galion, et comment la richesse est perçue et utilisée dans le monde du jeu.",
});
</script>
