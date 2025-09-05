// For Nuxt 3
import { library, config } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import {
  faArrowUp,
  faBook,
  faBrain,
  faCartShopping,
  faChartSimple,
  faCheck,
  faCodeBranch,
  faDumbbell,
  faExclamation,
  faFlag,
  faGem,
  faGraduationCap,
  faGrip,
  faHandFist,
  faHeart,
  faIdCard,
  faKitchenSet,
  faLandmark,
  faLightbulb,
  faList,
  faMagnifyingGlassChart,
  faPaw,
  faPersonHiking,
  faRotateRight,
  faScrewdriverWrench,
  faTimes,
  faTriangleExclamation,
  faWandSparkles,
  faWheelchair,
} from "@fortawesome/free-solid-svg-icons";

config.autoAddCss = false;

library.add(
  faArrowUp,
  faBook,
  faBrain,
  faCartShopping,
  faChartSimple,
  faCheck,
  faCodeBranch,
  faDumbbell,
  faExclamation,
  faFlag,
  faGem,
  faGraduationCap,
  faGrip,
  faHandFist,
  faHeart,
  faIdCard,
  faKitchenSet,
  faLandmark,
  faLightbulb,
  faList,
  faMagnifyingGlassChart,
  faPaw,
  faPersonHiking,
  faRotateRight,
  faScrewdriverWrench,
  faTimes,
  faTriangleExclamation,
  faWandSparkles,
  faWheelchair,
);

export default defineNuxtPlugin((nuxtApp) => {
  nuxtApp.vueApp.component("font-awesome-icon", FontAwesomeIcon);
});
