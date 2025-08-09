<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>L’équipement des personnages n’est pas éternel, et peut être brisé. Également, l’équipement de ses adversaires fait très souvent partie du butin.</p>
    <h2 class="h3">Vente d’équipement</h2>
    <p>
      Au fil de ses aventures, les personnages acquerront probablement des trésors ou des objets qu’ils désireront vendre ou échanger contre d’autres biens. La
      valeur de revente d’un objet varie en fonction de sa nature.
    </p>
    <ul>
      <li>
        <strong>Armes, armures et équipements.</strong> Lorsqu’en bonne condition, ces objets peuvent être vendus pour la moitié de leur coût d’achat.
        Lorsqu’ils sont brisés ou en mauvais état, leur valeur de revente est moindre, et souvent nulle.
      </li>
      <li>
        <strong>Artefacts magiques.</strong> Les artefacts magiques ou uniques n’ont généralement pas de valeur fixe. À moins qu’ils soient fréquents et vendus
        dans les grands centres commerciaux, leur valeur s’élève à ce qu’un acheteur est prêt à débourser pour l’artefact. Trouver un client fortuné à qui
        vendre un artefact magique peut être une tâche ardue.
      </li>
      <li>
        <strong>Marchandises.</strong> Les ressources brutes, titres de propriété et produits de transformation sont considérés comme des marchandises. À
        l’extérieur des centres urbains, la plupart des transactions sont conclues par le troc. La valeur des marchandises varie selon leur difficulté d’accès
        dans la région dans laquelle elles sont vendues. Cette difficulté d’accès est généralement déterminée par leur rareté naturelle ou contrôlée.
      </li>
      <li>
        <strong>Œuvres d’art, bijoux et pierres précieuses.</strong> Les objets de cette nature conservent généralement leur valeur initiale lors de la revente.
        Ils peuvent également être utilisés afin d’effectuer une transaction nécessitant une grande somme d’argent. Ces objets pourraient également être mis en
        enchère afin de réaliser un profit.
      </li>
    </ul>
    <h2 class="h3">Réparation d’équipement</h2>
    <p>La réparation d’un équipement est toujours moins onéreuse que l’achat d’un nouvel exemplaire.</p>
    <p>
      Le coût de réparation d’un équipement varie généralement entre 25 % et 50 % de son prix d’achat, en fonction de son état, des habiletés de l’artisan
      effectuant la réparation et des ressources nécessaires.
    </p>
    <p>Certains équipements peuvent être brisés définitivement, à la discrétion du maître de jeu, et ne peuvent donc pas être réparés.</p>
    <p>
      On raconte que certains artisans partent à l’aventure et financent leurs expéditions en réparant puis en vendant les objets endommagés ou brisés qu’ils
      trouvent pendant leur voyage.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Vente et réparation d’équipement";

useSeo({
  title,
  description: "Découvrez comment vendre, échanger ou réparer l’équipement et les trésors trouvés lors de vos aventures pour en tirer le meilleur profit.",
});
</script>
