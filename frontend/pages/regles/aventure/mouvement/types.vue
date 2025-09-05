<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Types" :parent="parent" />
    <p>
      Il existe plusieurs types de mouvement. Une créature peut avoir une <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink> différente pour
      chaque type de mouvement. Certains types de mouvement sont réservés à certaines créatures, et ne sont donc pas disponibles à toutes.
    </p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#marche">Marche</a>
        <ul>
          <li>
            <a href="#course">Course</a>
          </li>
          <li>
            <a href="#ramper">Ramper</a>
          </li>
          <li>
            <a href="#relever">Se relever</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#escalade">Escalade</a>
      </li>
      <li>
        <a href="#natation">Natation</a>
      </li>
      <li>
        <a href="#sauter">Sauter</a>
        <ul>
          <li>
            <a href="#saut-longueur">Saut en longueur</a>
          </li>
          <li>
            <a href="#saut-hauteur">Saut en hauteur</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#monter">Monter / Démonter</a>
      </li>
      <li>
        <a href="#voler">Voler</a>
        <ul>
          <li>
            <a href="#levitation">Lévitation</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#creuser">Creuser</a>
      </li>
    </ul>
    <h2 id="marche" class="h3">Marche</h2>
    <p>C’est le type de mouvement le plus répandu. Presque toute créature est dotée d’une vitesse pour ce type.</p>
    <h3 id="course" class="h5">Course</h3>
    <p>
      Une créature court lorsqu’elle effectue plusieurs actions <strong>Déplacement</strong> au cours du même
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>. Une créature se déplaçant en courant ne peut se
      <NuxtLink to="/regles/aventure/mouvement/furtif">déplacer furtivement</NuxtLink>, elle subit une pénalité à la
      <NuxtLink to="/regles/aventure/mouvement/attentif">perception</NuxtLink>, et peut subir une chute sur du
      <NuxtLink to="/regles/aventure/mouvement/terrain-difficile">terrain difficile</NuxtLink>. Une créature ne peut courir sur de longues périodes de temps.
    </p>
    <h3 id="ramper" class="h5">Ramper</h3>
    <p>
      Lorsqu’une créature est <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink> au sol, elle ne peut se déplacer qu’en rampant. Sa vitesse
      de marche est alors réduite de moitié. Les créatures ne pouvant être renversées au sol ne sont pas affectées par cette réduction de vitesse.
    </p>
    <p>
      Elle dépense <NuxtLink to="/regles/aventure/mouvement/vitesse">2 points de mouvement</NuxtLink> par tranche de 1,5 mètres en situation de tour-par-tour,
      et doit adopter une <NuxtLink to="/regles/aventure/mouvement/voyage">cadence prudente</NuxtLink> sur une longue période de
      <NuxtLink to="/regles/aventure/temps">temps</NuxtLink>.
    </p>
    <h3 id="relever" class="h5">Se relever</h3>
    <p>
      Lorsqu’une créature est <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink> au sol, elle peut se relever par l’action
      <strong>Déplacement</strong>. Il lui en coûte la moitié de ses
      <NuxtLink to="/regles/aventure/mouvement/vitesse">points de mouvement</NuxtLink> lorsqu’elle en fait ainsi.
    </p>
    <h2 id="escalade" class="h3">Escalade</h2>
    <p>
      Ce type de mouvement permet de se déplacer sur une surface verticale ou très en pente. Un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink> par action
      <strong>Déplacement</strong> est généralement requis, à la discrétion du maître de jeu.
    </p>
    <p>
      À moins d’être dotée d’une vitesse spécifique, la vitesse d’escalade d’une créature est égale à la moitié de sa vitesse de marche. Les insectes,
      arachnides et primates sont souvent dotés d’une vitesse d’escalade.
    </p>
    <p>
      Elle dépense <NuxtLink to="/regles/aventure/mouvement/vitesse">2 points de mouvement</NuxtLink> par tranche de 1,5 mètres en situation de tour-par-tour,
      et doit adopter une <NuxtLink to="/regles/aventure/mouvement/voyage">cadence prudente</NuxtLink> sur une longue période de
      <NuxtLink to="/regles/aventure/temps">temps</NuxtLink>.
    </p>
    <h2 id="natation" class="h3">Natation</h2>
    <p>
      Ce type de mouvement permet de se déplacer dans une surface liquide, comme de l’eau ou un liquide à densité similaire. Un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink> par action
      <strong>Déplacement</strong> est généralement requis, à la discrétion du maître de jeu.
    </p>
    <p>
      À moins d’être dotée d’une vitesse spécifique, la vitesse de nage d’une créature est égale à la moitié de sa vitesse de marche. Les créatures aquatiques
      sont souvent dotées d’une vitesse de nage.
    </p>
    <p>
      Elle dépense <NuxtLink to="/regles/aventure/mouvement/vitesse">2 points de mouvement</NuxtLink> par tranche de 1,5 mètres en situation de tour-par-tour,
      et doit adopter une <NuxtLink to="/regles/aventure/mouvement/voyage">cadence prudente</NuxtLink> sur une longue période de
      <NuxtLink to="/regles/aventure/temps">temps</NuxtLink>.
    </p>
    <h2 id="sauter" class="h3">Sauter</h2>
    <p>Une créature peut effectuer un saut en longueur ou en hauteur.</p>
    <h3 id="saut-longueur" class="h5">Saut en longueur</h3>
    <p>Une créature peut effectuer un saut d’une distance maximale de <code>150 + (Vigueur × 30)</code> centimètres.</p>
    <ul>
      <li>Cette distance est doublée si elle prend un élan d’une distance de 3 mètres ou plus.</li>
      <li>
        Pour sauter par-dessus un obstacle, par exemple une haie, la créature doit réussir un
        <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink>.
      </li>
      <li>
        Si elle atterit sur du <NuxtLink>terrain difficile</NuxtLink>, elle doit également réussir un test d’<NuxtLink to="/regles/competences/acrobaties"
          >Acrobaties</NuxtLink
        >
        afin de ne pas tomber <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink> au sol.
      </li>
    </ul>
    <h3 id="saut-hauteur" class="h5">Saut en hauteur</h3>
    <p>Une créature peut effectuer un saut d’une hauteur maximale de <code>(3 + Vigueur) × 15</code> centimètres (minimum 0).</p>
    <ul>
      <li>Cette distance est doublée si elle prend un élan d’une distance de 3 mètres ou plus.</li>
      <li>
        À la discrétion d’un maître de jeu, un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/athletisme"
          >Athlétisme</NuxtLink
        >
        pourrait permettre d’effectuer un saut à une hauteur légèrement supérieure.
      </li>
      <li>
        Si la créature étend ses bras vers le haut, elle peut ajouter jusqu’à 1½ fois sa <NuxtLink to="/regles/especes/taille">taille</NuxtLink> à la hauteur du
        saut.
      </li>
    </ul>
    <h2 id="monter" class="h3">Monter / Démonter</h2>
    <p>
      Une créature peut monter ou démonter sa monture par l’action <strong>Déplacement</strong>. Il lui en coûte la moitié de ses
      <NuxtLink to="/regles/aventure/mouvement/vitesse">points de mouvement</NuxtLink> lorsqu’elle en fait ainsi.
    </p>
    <p>
      Elle peut également démonter sa monture en se <strong>jetant au sol</strong> en <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>,
      mais elle tombe alors <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink> au sol.
    </p>
    <h2 id="voler" class="h3">Voler</h2>
    <p>Une créature dotée d’une vitesse de vol peut effectuer des déplacements aériens. Les créatures ailées sont généralement dotées d’une vitesse de vol.</p>
    <p>
      Une fois par <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, elle doit effectuer l’action <strong>Déplacement</strong> afin de se
      maintenir dans les airs, même si elle reste sur place.
    </p>
    <p>
      Si elle est <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink> en plein vol ou qu’elle perd sa capacité à voler, elle tombe et subit
      une <NuxtLink to="/regles/aventure/environnement/chute">chute</NuxtLink>.
    </p>
    <h3 id="levitation" class="h5">Lévitation</h3>
    <p>La capacité à léviter est rare et généralement magique.</p>
    <p>
      Une créature dotée de cette capacité n’a pas besoin de se déplacer continuellement afin de se maintenir dans les airs. Si elle est immobilisée ou perd
      conscience, elle reste en position.
    </p>
    <p>
      Si elle est <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink> alors qu’elle lévite, elle ne perd pas d’altitude, mais elle perd tout
      de même l’équilibre et se voit affligée des mêmes pénalités qu’une créature terrestre. Si elle perd sa capacité à léviter, elle tombe et subit une
      <NuxtLink to="/regles/aventure/environnement/chute">chute</NuxtLink>.
    </p>
    <h2 id="creuser" class="h3">Creuser</h2>
    <p>Une créature dotée d’une vitesse de creusage peut se déplacer sous terre, dans des surfaces friables tel le sable, la terre, la boue ou la glace.</p>
    <p>Elle ne peut néanmoins se déplacer dans des surfaces solides telle la pierre, sauf indication contraire.</p>
    <p>Les créatures souterraines, tels les vers, peuvent être dotées d’une vitesse de creusage.</p>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Mouvement", to: "/regles/aventure/mouvement" },
];
const title: string = "Types de mouvement";

useSeo({
  title,
  description: "Découvrez les différents types de mouvement des créatures : marche, course, escalade, nage, saut, vol, lévitation ou creusage.",
});
</script>
