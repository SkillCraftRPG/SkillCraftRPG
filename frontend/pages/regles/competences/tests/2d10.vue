<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Le résultat d’un <NuxtLink to="/regles/competences/tests">test</NuxtLink> est déterminé à l’aide d’un jet de 2d10 auquel on additionne une série de
      modificateurs.
    </p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#des">Dés d’Espérance et de Damnation</a>
      </li>
      <li>
        <a href="#deroulement">Déroulement du test</a>
        <ul>
          <li>
            <a href="#situation">Bonus et pénalités situationnels</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#resultat">Résultat du test</a>
      </li>
      <li>
        <a href="#exemples">Exemples</a>
        <ul>
          <li>
            <a href="#reussite-esperance">Réussite avec Espérance</a>
          </li>
          <li>
            <a href="#reussite-damnation">Réussite avec Damnation</a>
          </li>
          <li>
            <a href="#echec-esperance">Échec avec Espérance</a>
          </li>
          <li>
            <a href="#echec-damnation">Échec avec Damnation</a>
          </li>
        </ul>
      </li>
    </ul>
    <h2 id="des" class="h3">Dés d’Espérance et de Damnation</h2>
    <ul>
      <li>Désignez un de ces dés comme dé d’Espérance, et l’autre comme dé de Damnation.</li>
      <li>
        <font-awesome-icon icon="fas fa-lightbulb" /> Si vous ne possédez qu’une paire de d10 (unité et dizaine), utilisez votre dé d’unité comme dé d’Espérance
        ainsi que votre dé de dizaine comme dé de Damnation.
      </li>
      <li>
        Autrement, désignez vos dés d’Espérance et de Damnation par une couleur, un symbole ou des motifs, par exemple :
        <ul>
          <li>
            <strong>Dé d’Espérance.</strong> Blanc, vert ou bleu, orné de motifs inspirant le courage et la victoire, désigné par un symbole que vous associez à
            la chance ou à votre personnage.
          </li>
          <li>
            <strong>Dé de Damnation.</strong> Noir, rouge ou violet, orné de motifs inspirant la peur et la défaite, désigné par un symbole représentant la
            mort, une blessure ou vos ennemis.
          </li>
        </ul>
      </li>
    </ul>
    <h2 id="deroulement" class="h3">Déroulement du test</h2>
    <ol>
      <li>Jetez vos dés d’Espérance et de Damnation.</li>
      <li>
        Si les deux dés tombent sur la face 6, 7, 8, 9 ou 0 du dé, vous obtenez une
        <NuxtLink to="/regles/competences/tests/critique">réussite critique</NuxtLink>. Le test est terminé.
      </li>
      <li>
        Si les deux dés tombent sur la face 1, 2, 3, 4 ou 5 du dé, vos obtenez un <NuxtLink to="/regles/competences/tests/critique">échec critique</NuxtLink>.
        Le test est terminé.
      </li>
      <li>Sinon, ajoutez la valeur de l’<NuxtLink to="/regles/attributs">attribut</NuxtLink> associé au test.</li>
      <li>
        Ajoutez le <NuxtLink to="/regles/competences/rang">rang</NuxtLink> de la <NuxtLink to="/regles/competences">compétence</NuxtLink> associée au test si
        votre personnage est <NuxtLink to="/regles/competences/formation">formé</NuxtLink> pour cette compétence, ou seulement la moitié du rang sinon.
      </li>
      <li>Ajoutez les bonus et pénalités situationnels (s’il y a lieu).</li>
      <li>
        Comparez la face sur laquelle vos dés d’Espérance et de Damnation sont tombés.
        <ul>
          <li>
            Si la face de votre dé d’Espérance est supérieure à celle de votre dé de Damnation, énoncez votre total et mentionnez « <i>avec Espérance</i> ».
          </li>
          <li>
            Si la face de votre dé de Damnation est supérieure à celle de votre dé d’Espérance, énoncez votre total et mentionnez « <i>avec Damnation</i> ».
          </li>
        </ul>
      </li>
    </ol>
    <h3 id="situation" class="h5">Bonus et pénalités situationnels</h3>
    <p>
      Un bonus situationnel est octroyé par le maître de jeu au test d’une créature lorsque la situation ou le contexte lui est favorable. Par exemple, un
      personnage issue d’une famille riche pourrait se voir octroyer un bonus situationnel lorsqu’il tente de convaincre un noble de lui porter assistance.
    </p>
    <p>
      Au contraire, une pénalité situationnelle est infligée par le maître de jeu lorsque la situation ou le contexte est défavorable à une créature. Par
      exemple, une créature tentant d’escalader une paroi glissante pourra se voir affligée d’une pénalité situationnelle.
    </p>
    <h2 id="resultat" class="h3">Résultat du test</h2>
    <p>Le maître de jeu compare votre résultat avec un <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink>.</p>
    <p>Si votre résultat est supérieur ou égal à cette valeur, l’action entreprise est réussie. Sinon, l’action est soldée par un échec.</p>
    <p>En combinant Espérance/Damnation et réussite/échec, un test peut se conclure par une des possibilités suivantes :</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-10"></th>
          <th scope="col" class="w-45">Espérance</th>
          <th scope="col" class="w-45">Damnation</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <th scope="row">Réussite</th>
          <td>L’action entreprise est réussie et une conséquence positive survient.</td>
          <td>L’action entreprise est réussie, mais une conséquence négative survient.</td>
        </tr>
        <tr>
          <th scope="row">Échec</th>
          <td>L’action intentée est échouée, mais une conséquence positive survient.</td>
          <td>L’action intentée est échouée et une conséquence négative survient.</td>
        </tr>
      </tbody>
    </table>
    <p>Vous pouvez suggérer des conséquences à votre maître de jeu, mais la décision finale lui appartient.</p>
    <p>
      Dans le feu de l’action, si votre maître de jeu n’arrive pas à trouver une conséquence, il peut vous donner un
      <NuxtLink to="/regles/competences/esperance-damnation">point d’Espérance</NuxtLink> en tant que conséquence positive, et s’allouer un
      <NuxtLink to="/regles/competences/esperance-damnation">point de Damnation</NuxtLink> en tant que conséquence négative.
    </p>
    <h2 id="exemples" class="h3">Exemples</h2>
    <h3 id="reussite-esperance" class="h5">Réussite avec Espérance</h3>
    <p>Vous tentez de trouver de l’eau potable, alors que vous êtes perdus en milieu sauvage.</p>
    <ul>
      <li>Vous obtenez 7 sur votre dé d’Espérance et 5 sur votre dé de Damnation.</li>
      <li>
        Vous ajoutez vos <NuxtLink to="/regles/attributs/sens">Sens</NuxtLink>, soit 3, ainsi que la moitié de votre rang de
        <NuxtLink to="/regles/competences/survie">Survie</NuxtLink>, soit 2 pour un rang de 4, puisque votre personnage n’est pas formé pour cette compétence.
      </li>
      <li>Vous obtenez <i>17 avec Espérance</i>, ce qui est suffisant face au degré de difficulté de 15.</li>
      <li>
        Votre personnage parvient à trouver un cours d’eau potable (réussite) et trouve également fruits sauvages qui permettront à son groupe de repousser la
        faim de quelques heures (conséquence positive).
      </li>
    </ul>
    <h3 id="reussite-damnation" class="h5">Réussite avec Damnation</h3>
    <p>Vous tentez de crocheter la serrure d’un coffre que vous savez rempli de pièces d’or.</p>
    <ul>
      <li>Vous obtenez 8 sur votre dé d’Espérance et 10 (0) sur votre dé de Damnation.</li>
      <li>
        Vous ajoutez votre <NuxtLink to="/regles/attributs/adresse">Adresse</NuxtLink>, soit 4, ainsi que votre rang de
        <NuxtLink to="/regles/competences/roublardise">Roublardise</NuxtLink>, soit 8.
      </li>
      <li>Vous obtenez donc <i>30 avec Damnation</i>, ce qui est largement supérieur au degré de difficulté de 20.</li>
      <li>
        Votre personnage parvient à crocheter la serrure du coffre (réussite), mais son outil de crochetage brise, le rendant inutilisable (conséquence
        négative).
      </li>
    </ul>
    <h3 id="echec-esperance" class="h5">Échec avec Espérance</h3>
    <p>Vous tentez de nager dans des rapides.</p>
    <ul>
      <li>Vous obtenez 6 sur votre dé d’Espérance et 4 sur votre dé de Damnation.</li>
      <li>
        Vous ajoutez votre <NuxtLink to="/regles/attributs/vigueur">Vigueur</NuxtLink>, soit 2, ainsi que la moitié de votre rang d’<NuxtLink
          to="/regles/competences/athletisme"
          >Athlétisme</NuxtLink
        >, soit 3 pour un rang de 7, puisque votre personnage n’est pas formé pour cette compétence.
      </li>
      <li>Le maître de jeu inflige une pénalité de -2 au test puisque la température de l’eau est glaciale.</li>
      <li>Vos obtenez donc <i>13 avec Espérance</i>, ce qui n’est pas suffisant face au degré de difficulté de 15.</li>
      <li>
        Votre personnage est emporté par le courant (échec), mais il réussit à s’agripper à la branche d’un arbre sur les berges, mettant fin à sa dérive
        (conséquence positive).
      </li>
    </ul>
    <h3 id="echec-damnation" class="h5">Échec avec Damnation</h3>
    <p>Vous tentez de négocier le prix de nourriture dans un pays étranger, utilisant votre connaissance des prix dans votre pays.</p>
    <ul>
      <li>Vous obtenez 1 sur votre dé d’Espérance et 3 sur votre dé de Damnation.</li>
      <li>
        Vous ajoutez votre <NuxtLink to="/regles/attributs/intellect">Intellect</NuxtLink>, soit 1, ainsi que votre rang de
        <NuxtLink to="/regles/competences/diplomatie">Diplomatie</NuxtLink>, soit 6.
      </li>
      <li>Le maître de jeu ajoute un bonus de 2 au test puisque votre personnage a peu mangé dans les derniers jours et son ventre gargouille sans cesse.</li>
      <li>Vous obtenez donc <i>13 avec Damnation</i>, ce qui est inférieur au degré de difficulté de 15.</li>
      <li>
        Votre personnage propose un prix dérisoire, qui est refusé par le marchand (échec). Le marchand refuse ensuite de commercer avec vous pour le reste de
        la journée à cause de votre prix dérisoire (conséquence négative).
      </li>
    </ul>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Compétences", to: "/regles/competences" },
  { text: "Tests", to: "/regles/competences/tests" },
];
const title: string = "Système 2d10";

function scrollToTop(): void {
  window.history.replaceState(window.history.state, "", window.location.pathname + window.location.search);
  window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
}

useSeo({
  title,
  description:
    "Découvrez le système de résolution combinant attributs, compétences, Espérance et Damnation pour résoudre des tests avec conséquences positives ou négatives.",
});
</script>
